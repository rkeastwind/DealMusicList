using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealMusicList
{
    public partial class MainForm : Form
    {
        string RText = "";  //訊息
        FileInfo[] files;  //檔案清單
        DirectoryInfo[] dirList;  //目錄清單
        List<string[]> ICount = new List<string[]>();  //識別碼計數
        string ModuleName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName.Replace(".exe", "");  //模組名稱

        public MainForm()
        {
            InitializeComponent();
            btExec.Enabled = false;
        }

        private void BtPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.txtPath.Text = path.SelectedPath;
            BtnControl();
        }

        private void CbIdentity_CheckedChanged(object sender, EventArgs e)
        {
            BtnControl();
        }

        private void Dddigit_SelectedItemChanged(object sender, EventArgs e)
        {
            BtnControl();
        }

        private void BtnControl()
        {
            txtDataAnay.Clear();
            dgvfolderlist.Rows.Clear();
            if (txtPath.Text != "")
            {
                btExec.Enabled = Analysis();
                txtDataAnay.SelectionColor = (btExec.Enabled == false) ? Color.Red : Color.Black;
                txtDataAnay.AppendText(RText);
                //顯示路徑下資料夾大小，方便管理
                DirSpaceAnalysis();
            }
        }

        private bool Analysis()
        {
            RText = "【解析結果】" + "\r\n";
            bool check = true;

            //取得路徑所有檔案or路徑清單(排除隱藏資料夾)
            DirectoryInfo di = new DirectoryInfo(txtPath.Text);
            files = di.GetFiles();
            dirList = di.GetDirectories().Where(x => !x.Attributes.ToString().Contains("Hidden")).ToArray();

            //依檔名排序
            Array.Sort(files, delegate (FileInfo x, FileInfo y) { return x.Name.CompareTo(y.Name); });

            //檢核是否有檔案
            if (files.AsEnumerable().Select(x => x).Count() == 0)
            {
                RText += "資料夾內無檔案" + "\r\n";
                return check = false;
            }

            //計算檔案數量
            ICount.Clear();
            List<string> IdenList = new List<string>();
            if (cbIdentity.Checked == false)
            {
                ICount.Add(new string[]
                {
                    "",
                    files.AsEnumerable().Select(x => x).Count().ToString()
                });
            }
            else
            {
                IdenList = files.AsEnumerable().Select(row => row.Name.Split('.')[0]).Distinct().OrderBy(x => x).ToList();
                foreach (string Iden in IdenList)
                {
                    ICount.Add(new string[]
                    {
                        Iden,
                        files.AsEnumerable().Select(x => x).Where(row => row.Name.Split('.')[0].Contains(Iden)).Count().ToString()
                    });
                }
            }

            //檢核編碼位數
            foreach (string[] Co in ICount)
            {
                if (Co[1].Length > int.Parse(Dddigit.Text))
                {
                    RText += "檔案數量與編碼位數不符" + "\r\n";
                    return check = false;
                }
            }

            //避免選錯資料夾，檢核前5筆資料，編號必須為1-5
            if (int.Parse(ICount[0][1]) >= 5)
            {
                if (cbIdentity.Checked == false)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (!int.TryParse(files[i].Name.Split('.')[0], out _))
                        {
                            RText += "檢核前5筆資料" + "\r\n" + "無識別碼，第一個「.」前必須為數字" + "\r\n";
                            return check = false;
                        }
                        else if (i + 1 != int.Parse(files[i].Name.Split('.')[0]))  //第一個「.」
                        {
                            RText += "檢核前5筆資料" + "\r\n" + "編號必須為1-5" + "\r\n";
                            return check = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (!int.TryParse(files[i].Name.Split('.')[1], out _))
                        {
                            RText += "檢核前5筆資料" + "\r\n" + "有識別碼，第二個「.」前必須為數字" + "\r\n";
                            return check = false;
                        }
                        else if (i + 1 != int.Parse(files[i].Name.Split('.')[1]))  //第二個「.」
                        {
                            RText += "檢核前5筆資料" + "\r\n" + "編號必須為1-5" + "\r\n";
                            return check = false;
                        }
                    }
                }
            }
            else
            {
                RText += "第一識別碼資料小於5筆" + "\r\n";
                return check = false;
            }

            if (check == true)
            {
                foreach (string[] Co in ICount)
                {
                    RText += "識別碼：" + Co[0] + "  總數：" + Co[1] + "\r\n";
                }
            }

            return check;
        }

        private void DirSpaceAnalysis()
        {
            long FolderSize;
            string SizeDes;
            //依檔名排序
            Array.Sort(dirList, delegate (DirectoryInfo x, DirectoryInfo y) { return x.Name.CompareTo(y.Name); });

            //檢核是否有檔案
            if (dirList.AsEnumerable().Select(x => x).Count() != 0)
            {
                DataGridViewRowCollection rows = dgvfolderlist.Rows;

                foreach (DirectoryInfo dir in dirList)
                {
                    FolderSize = GetFolderSize(dir.FullName);
                    if (FolderSize == -1)
                    {
                        SizeDes = "權限不足無法解析";
                    }
                    else
                    {
                        SizeDes = CvtSize(FolderSize);
                    }
                    rows.Add(new Object[] { dir.Name, SizeDes, FolderSize });
                }

                for (int i = 0; i < dirList.Count(); i++)
                {
                    DataGridViewCell CoSpace = dgvfolderlist.Rows[i].Cells[1];
                    if (CoSpace.Value.ToString() == "權限不足無法解析")
                        CoSpace.Style.ForeColor = Color.Magenta;
                }
            }
        }

        static long GetFolderSize(string folder)  //用反射寫法取得
        {
            try
            {
                Type tp = Type.GetTypeFromProgID("Scripting.FileSystemObject");
                object fso = Activator.CreateInstance(tp);
                object fd = tp.InvokeMember("GetFolder", BindingFlags.InvokeMethod, null, fso, new object[] { folder });
                long ret = Convert.ToInt64(tp.InvokeMember("Size", BindingFlags.GetProperty, null, fd, null));
                Marshal.ReleaseComObject(fso);
                return ret;
            }
            catch
            {
                return -1;
            }
        }

        public static string CvtSize(long size)  // 單位轉換
        {
            var num = 1024.00; //byte

            if (size < num)
                return size + "B";
            if (size < Math.Pow(num, 2))
                return (size / num).ToString("f2") + "KB";
            if (size < Math.Pow(num, 3))
                return (size / Math.Pow(num, 2)).ToString("f2") + "MB";
            if (size < Math.Pow(num, 4))
                return (size / Math.Pow(num, 3)).ToString("f2") + "GB";
            return (size / Math.Pow(num, 4)).ToString("f2") + "TB";
        }

        private void BtExec_Click(object sender, EventArgs e)
        {
            int fc = 0;
            int nm; //當前曲目序號
            string IdenC;  //當前識別碼
            string Fname;  //當前完整檔名
            string Serial;  //新曲目編號
            string filename;  //新去掉序號檔案名稱
            string newfname;  //新完整檔名
            string LogData = "";
            if (cbIdentity.Checked == false)
            {
                for (int i = 0; i < int.Parse(ICount[0][1]); i++)
                {
                    nm = i + 1;
                    Fname = files[i].Name;

                    Serial = SerialConvert(nm, int.Parse(Dddigit.Text));
                    filename = Fname.Substring(Fname.IndexOf('.') + 1).Trim();
                    newfname = Serial + ". " + filename;

                    if (Fname != newfname)  //若當前檔案名稱不同才更新
                    {
                        UpdateName(files[i], newfname);
                        LogData += Fname + " => " + newfname + "\r\n";
                    }
                }
            }
            else
            {
                for (int x = 0; x < ICount.Count(); x++)  //識別碼
                {
                    for (int i = 0; i < int.Parse(ICount[x][1]); i++)
                    {
                        IdenC = ICount[x][0];
                        nm = i + 1;
                        Fname = files[fc].Name;

                        Serial = IdenC + "." + SerialConvert(nm, int.Parse(Dddigit.Text));
                        filename = Fname.Substring(Fname.IndexOf('.', Fname.IndexOf('.') + 1) + 1).Trim(); //取第二個「.」之後
                        newfname = Serial + ". " + filename;

                        if (Fname != newfname)  //若當前檔案名稱不同才更新
                        {
                            UpdateName(files[fc], newfname);
                            LogData += Fname + " => " + newfname + "\r\n";
                        }
                        fc += 1;
                    }
                }
            }

            //寫入Log
            InsertLog(LogData);

            MessageBox.Show("修改完成" + "\r\n" + "修改紀錄請至 " + ModuleName + "Log.txt 查詢", "成功訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnControl();
        }

        private string SerialConvert(int nowc, int digit)
        {
            string result;
            result = Convert.ToString(nowc).PadLeft(digit, '0');
            return result;
        }

        private void UpdateName(FileInfo ofile, string newname)
        {
            ofile.MoveTo(Path.Combine(ofile.DirectoryName, newname));
        }

        private void InsertLog(string LogData)
        {
            //今日日期
            DateTime Date = DateTime.Now;
            string TodyMillisecond = Date.ToString("yyyy-MM-dd HH:mm:ss");

            string DataName = ModuleName + "Log.txt";
            File.AppendAllText(DataName, "《" + TodyMillisecond + "》" + "\r\n" + LogData + "\r\n");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Infomation f = new Infomation();
            f.ShowDialog(this);
        }

        //選擇大小時用Byte欄位排序，CoSpace欄位SortMode參數要設為Programmatic
        private void Dgvfolderlist_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var col = dgvfolderlist.Columns[e.ColumnIndex];
            if (col.Name == "CoSpace")
            {
                ListSortDirection direction;
                SortOrder newsortOrder;
                if (dgvfolderlist.SortOrder == (SortOrder.Descending | SortOrder.None))
                {
                    direction = ListSortDirection.Ascending;
                    newsortOrder = SortOrder.Ascending;
                }
                else
                {
                    direction = ListSortDirection.Descending;
                    newsortOrder = SortOrder.Descending;
                }

                dgvfolderlist.Sort(dgvfolderlist.Columns["CoByte"], direction);

                //回寫三角形符號
                dgvfolderlist.Columns["CoSpace"].HeaderCell.SortGlyphDirection = newsortOrder;
            }
            else
            {
                //清除三角形符號
                dgvfolderlist.Columns["CoSpace"].HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }
    }
}
