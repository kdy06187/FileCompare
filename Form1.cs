
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
        public bool IsDirectory { get; set; }
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

                    // 폴더 비교 데이터 태그 저장
                    item.Tag = new FileItemData 
                    { 
                        LastWriteTime = d.LastWriteTime, 
                        Status = FileCompareStatus.None,
                        IsDirectory = true
                    };
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
                        Status = FileCompareStatus.None,
                        IsDirectory = false
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
                // FileItemData 태그를 가진 항목(파일 및 폴더 모두) 추출
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

        private void btnCopyFromRight_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLeftDir.Text) || string.IsNullOrWhiteSpace(txtRightDir.Text)) return;

            bool copiedAny = false;
            foreach (ListViewItem item in lvwLeftDir.SelectedItems)
            {
                if (!(item.Tag is FileItemData itemData)) continue;

                var srcPath = Path.Combine(txtLeftDir.Text, item.Text);
                var destPath = Path.Combine(txtRightDir.Text, item.Text);

                if (CopyItemWithConfirmation(srcPath, destPath, itemData.IsDirectory))
                {
                    copiedAny = true;
                }
            }

            if (copiedAny)
            {
                // 복사 완료 후 새 항목 로드 및 재비교
                PopulateListView(lvwrightDir, txtRightDir.Text);
                CompareFiles();
            }
        }

        private void btnCopyFromLeft_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLeftDir.Text) || string.IsNullOrWhiteSpace(txtRightDir.Text)) return;

            bool copiedAny = false;
            foreach (ListViewItem item in lvwrightDir.SelectedItems)
            {
                if (!(item.Tag is FileItemData itemData)) continue;

                var srcPath = Path.Combine(txtRightDir.Text, item.Text);
                var destPath = Path.Combine(txtLeftDir.Text, item.Text);

                if (CopyItemWithConfirmation(srcPath, destPath, itemData.IsDirectory))
                {
                    copiedAny = true;
                }
            }

            if (copiedAny)
            {
                // 복사 완료 후 새 항목 로드 및 재비교
                PopulateListView(lvwLeftDir, txtLeftDir.Text);
                CompareFiles();
            }
        }

        private bool CopyItemWithConfirmation(string srcPath, string destPath, bool isDirectory)
        {
            if (isDirectory)
            {
                try
                {
                    if (!Directory.Exists(srcPath)) return false;

                    if (!Directory.Exists(destPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }

                    bool anyCopied = false;

                    // 하위 파일 재귀 복사
                    foreach (string file in Directory.GetFiles(srcPath))
                    {
                        string destFile = Path.Combine(destPath, Path.GetFileName(file));
                        if (CopyItemWithConfirmation(file, destFile, false))
                        {
                            anyCopied = true;
                        }
                    }

                    // 하위 폴더 재귀 복사
                    foreach (string folder in Directory.GetDirectories(srcPath))
                    {
                        string destFolder = Path.Combine(destPath, Path.GetFileName(folder));
                        if (CopyItemWithConfirmation(folder, destFolder, true))
                        {
                            anyCopied = true;
                        }
                    }

                    // 폴더 복사 완료 후, 대상 폴더의 수정 시간을 원본과 동일하게 맞춤(비교시 정확도 보장)
                    Directory.SetLastWriteTime(destPath, Directory.GetLastWriteTime(srcPath));

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "폴더 복사 중 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                try
                {
                    if (!File.Exists(srcPath)) return false;

                    if (File.Exists(destPath))
                    {
                        DateTime srcTime = File.GetLastWriteTime(srcPath);
                        DateTime destTime = File.GetLastWriteTime(destPath);

                        // 덮어쓸 파일(destPath)이 원본 파일(srcPath)보다 최신인 경우
                        if (destTime > srcTime)
                        {
                            var result = MessageBox.Show(this,
                                $"대상에 동일한 이름의 파일이 이미 있습니다. \n\n대상 파일이 더 최신 파일입니다. 덮어쓰시겠습니까?" +
                                $"[원본 파일]\n경로: {srcPath}\n수정일: {srcTime:yyyy-MM-dd HH:mm:ss}\n\n" +
                                $"[대상 파일]\n경로: {destPath}\n수정일: {destTime:yyyy-MM-dd HH:mm:ss}\n\n" +
                                $"오래된 파일로 덮어쓰시겠습니까?",
                                "덮어쓰기 확인",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (result != DialogResult.Yes)
                            {
                                return false; // 복사 취소
                            }
                        }
                    }

                    File.Copy(srcPath, destPath, true);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "파일 복사 중 오류: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

    }
}
