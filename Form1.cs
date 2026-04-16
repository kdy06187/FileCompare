
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace FileCompare
{
    public enum FileCompareStatus
    {
        None,
        Identical, // 동일
        New,       // 최신
        Old,       // 과거
        Unique     // 단독
    }

    public class FileItemData
    {
        public DateTime LastWriteTime { get; set; }
        public FileCompareStatus Status { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnLeftDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를선택하세요.";
                // 현재텍스트박스에있는경로를초기선택폴더로설정
                if (!string.IsNullOrWhiteSpace(txtLeftDir.Text) &&
                Directory.Exists(txtLeftDir.Text))
                {
                    dlg.SelectedPath = txtLeftDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtLeftDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwLeftDir, dlg.SelectedPath);
                    CompareFiles();
                }

            }
        }


        private void btnRightDir_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "폴더를선택하세요.";
                // 현재텍스트박스에있는경로를초기선택폴더로설정
                if (!string.IsNullOrWhiteSpace(txtRightDir.Text) &&
                Directory.Exists(txtRightDir.Text))
                {
                    dlg.SelectedPath = txtRightDir.Text;
                }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtRightDir.Text = dlg.SelectedPath;
                    PopulateListView(lvwrightDir, dlg.SelectedPath);
                    CompareFiles();
                }

            }
        }
        private void PopulateListView(ListView lv, string folderPath)
        {
            lv.BeginUpdate();
            lv.Items.Clear();
            try
            { // 폴더(디렉터리) 먼저추가
                var dirs = Directory.EnumerateDirectories(folderPath)
                                    .Select(p => new DirectoryInfo(p))
                                    .OrderBy(d => d.Name);
                foreach (var d in dirs)
                {
                    var item = new ListViewItem(d.Name);
                    item.SubItems.Add("<DIR>");
                    item.SubItems.Add(d.LastWriteTime.ToString("g"));
                    lv.Items.Add(item);
                }
                // 파일추가
                var files = Directory.EnumerateFiles(folderPath)
                                     .Select(p => new FileInfo(p))
                                     .OrderBy(f => f.Name);
                foreach (var f in files)
                {
                    var item = new ListViewItem(f.Name);
                    item.SubItems.Add(f.Length.ToString("N0") + " 바이트");
                    item.SubItems.Add(f.LastWriteTime.ToString("g"));

                    // 파일 비교 데이터 태그 저장
                    item.Tag = new FileItemData 
                    { 
                        LastWriteTime = f.LastWriteTime, 
                        Status = FileCompareStatus.None 
                    };
                    lv.Items.Add(item);
                }
                // 컬럼너비자동조정(컨텐츠기준)
                for (int i = 0; i < lv.Columns.Count; i++)
                {
                    lv.AutoResizeColumn(i,
                    ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(this, "폴더를찾을수없습니다.", "오류",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(this, "입출력오류: " + ex.Message, "오류",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lv.EndUpdate();
            }

        }

        private void CompareFiles()
        {
            // 양쪽 디렉터리가 모두 로드된 상태에서만 동작
            if (lvwLeftDir.Items.Count == 0 || lvwrightDir.Items.Count == 0) return;

            lvwLeftDir.BeginUpdate();
            lvwrightDir.BeginUpdate();

            try
            {
                // 디렉터리를 제외하고 FileItemData(파일) 태그를 가진 항목만 추출
                var leftItems = lvwLeftDir.Items.Cast<ListViewItem>()
                    .Where(i => i.Tag is FileItemData)
                    .ToDictionary(i => i.Text);

                var rightItems = lvwrightDir.Items.Cast<ListViewItem>()
                    .Where(i => i.Tag is FileItemData)
                    .ToDictionary(i => i.Text);

                foreach (var left in leftItems)
                {
                    var leftName = left.Key;
                    var leftItem = left.Value;
                    var leftData = (FileItemData)leftItem.Tag;

                    if (rightItems.TryGetValue(leftName, out var rightItem))
                    {
                        var rightData = (FileItemData)rightItem.Tag;

                        if (leftData.LastWriteTime == rightData.LastWriteTime)
                        {
                            leftData.Status = FileCompareStatus.Identical;
                            rightData.Status = FileCompareStatus.Identical;
                            leftItem.ForeColor = System.Drawing.Color.Black;
                            rightItem.ForeColor = System.Drawing.Color.Black;
                        }
                        else if (leftData.LastWriteTime > rightData.LastWriteTime)
                        {
                            leftData.Status = FileCompareStatus.New;
                            rightData.Status = FileCompareStatus.Old;
                            leftItem.ForeColor = System.Drawing.Color.Red;
                            rightItem.ForeColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            leftData.Status = FileCompareStatus.Old;
                            rightData.Status = FileCompareStatus.New;
                            leftItem.ForeColor = System.Drawing.Color.Gray;
                            rightItem.ForeColor = System.Drawing.Color.Red;
                        }

                        rightItems.Remove(leftName);
                    }
                    else
                    {
                        leftData.Status = FileCompareStatus.Unique;
                        leftItem.ForeColor = System.Drawing.Color.Purple;
                    }
                }

                foreach (var right in rightItems.Values)
                {
                    var rightData = (FileItemData)right.Tag;
                    rightData.Status = FileCompareStatus.Unique;
                    right.ForeColor = System.Drawing.Color.Purple;
                }
            }
            finally
            {
                lvwLeftDir.EndUpdate();
                lvwrightDir.EndUpdate();
            }
        }

        

    }
}
