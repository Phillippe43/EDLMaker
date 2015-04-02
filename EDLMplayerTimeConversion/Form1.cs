using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EDLMplayerTimeConversion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MUTE_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Select EDL File to Convert";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    string path = Path.GetDirectoryName(fileName);
                    string fileNameOld = Path.GetFileNameWithoutExtension(fileName);
                    string fileNameNew = fileNameOld + "_With_MUTES.edl";
                    string fileNameBat = fileNameOld + "_Shortcut.bat";
                    string newFile = path + "\\" + fileNameNew;
                    File.Create(newFile).Dispose();

                    // Pattern to check each line
                    Regex pattern1 = new Regex(@"(?:[0-3]):[0-5][0-9]:[0-5][0-9].[0-9][0-9]");


                    using (System.IO.StreamWriter writer = new StreamWriter(newFile))
                    {
                        using (System.IO.StreamReader reader = new StreamReader(fileName))
                        {
                            // Iterate through lines
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                var matches = pattern1.Matches(line);

                                if (matches.Count == 2)
                                {
                                    string oldchar = line;
                                    oldchar = oldchar.Trim();
                                    string Start = oldchar.Substring(1, 10);
                                    string End = oldchar.Substring(16, 10);
                                    //string rest = oldchar.Substring(28);
                                    Start = Start.Replace(',', '.');
                                    End = End.Replace(',', '.');
                                    //rest = rest.Replace(',', ' ');

                                    string StartHour = Start.Substring(0, 1);
                                    string StartMinute = Start.Substring(2, 2);
                                    string StartSecond = Start.Substring(5, 5);
                                    string EndHour = End.Substring(0, 1);
                                    string EndMinute = End.Substring(2, 2);
                                    string EndSecond = End.Substring(5, 5);

                                    decimal StartHourDec = Convert.ToDecimal(StartHour);
                                    decimal StartMinuteDec = Convert.ToDecimal(StartMinute);
                                    decimal StartSecondsDec = Convert.ToDecimal(StartSecond);
                                    decimal EndHourDec = Convert.ToDecimal(EndHour);
                                    decimal EndMinuteDec = Convert.ToDecimal(EndMinute);
                                    decimal EndSecondDec = Convert.ToDecimal(EndSecond);

                                    StartHourDec = StartHourDec * 3600;
                                    StartMinuteDec = StartMinuteDec * 60;
                                    StartSecondsDec = StartHourDec + StartMinuteDec + StartSecondsDec;
                                    string StartSecondsDecStr = String.Format("{0:0.000000}", StartSecondsDec);
                                    StartSecondsDecStr.Trim();

                                    EndHourDec = EndHourDec * 3600;
                                    EndMinuteDec = EndMinuteDec * 60;
                                    EndSecondDec = EndHourDec + EndMinuteDec + EndSecondDec;
                                    EndSecondDec = Math.Round(EndSecondDec, 4);
                                    string EndSecondDecStr = String.Format("{0:0.000000}", EndSecondDec);

                                    string newchar = StartSecondsDecStr + ' ' + EndSecondDecStr + ' ' + '1';
                                    newchar.Trim();
                                    line = line.Replace(oldchar, newchar);
                                    line.Trim();

                                    writer.WriteLine(line.Trim());

                                }

                            }
                        }
                    }

                }


                MessageBox.Show("Completed! HAVE FUN WATCHING YOUR MOVIE!");
            }
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }
        }

        private void SkipScene_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                MessageBox.Show("Select SKIP Scene File.");

                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Select SKIP Scene File";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string SkipFileName = openFileDialog1.FileName;
                    string SkipFilepath = Path.GetDirectoryName(SkipFileName);

                    OpenFileDialog openFileDialog2 = new OpenFileDialog();

                    MessageBox.Show("Select EDL file to merge with.");

                    openFileDialog2.InitialDirectory = @"C:\";
                    openFileDialog2.Title = "Select EDL File";

                    openFileDialog2.CheckFileExists = true;
                    openFileDialog2.CheckPathExists = true;

                    openFileDialog2.DefaultExt = "txt";
                    openFileDialog2.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog2.FilterIndex = 2;
                    openFileDialog2.RestoreDirectory = true;

                    openFileDialog2.ReadOnlyChecked = true;
                    openFileDialog2.ShowReadOnly = true;

                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        string EDLFileName = openFileDialog2.FileName;
                        string EDLFilepath = Path.GetDirectoryName(EDLFileName);
                        string fileNameOld = Path.GetFileNameWithoutExtension(EDLFileName);
                        string fileNameNew = fileNameOld + "Temp_Skip_Info.edl";
                        string newFile_temp = EDLFilepath + "\\" + fileNameNew;
                        File.Create(newFile_temp).Dispose();


                        // Pattern to check each line
                        Regex pattern1 = new Regex(@"(?:[0-3]):[0-5][0-9]:[0-5][0-9].[0-9][0-9]");

                        using (System.IO.StreamWriter writer = new StreamWriter(newFile_temp))
                        {
                            using (System.IO.StreamReader reader = new StreamReader(SkipFileName))
                            {
                                // Iterate through lines
                                while (!reader.EndOfStream)
                                {
                                    string line = reader.ReadLine();
                                    var matches = pattern1.Matches(line);

                                    if (matches.Count == 2)
                                    {
                                        string oldchar = line;
                                        oldchar.Trim();
                                        string Start = oldchar.Substring(0, 11);
                                        string End = oldchar.Substring(12, 11);
                                        //string rest = oldchar.Substring(21);
                                        Start = Start.Replace(',', '.');
                                        End = End.Replace(',', '.');

                                        string StartHour = Start.Substring(0, 2);
                                        string StartMinute = Start.Substring(3, 2);
                                        string StartSecond = Start.Substring(6, 5);
                                        string EndHour = End.Substring(0, 2);
                                        string EndMinute = End.Substring(3, 2);
                                        string EndSecond = End.Substring(6, 5);

                                        decimal StartHourDec = Convert.ToDecimal(StartHour);
                                        decimal StartMinuteDec = Convert.ToDecimal(StartMinute);
                                        decimal StartSecondsDec = Convert.ToDecimal(StartSecond);
                                        decimal EndHourDec = Convert.ToDecimal(EndHour);
                                        decimal EndMinuteDec = Convert.ToDecimal(EndMinute);
                                        decimal EndSecondDec = Convert.ToDecimal(EndSecond);

                                        StartHourDec = StartHourDec * 3600;
                                        StartMinuteDec = StartMinuteDec * 60;
                                        StartSecondsDec = StartHourDec + StartMinuteDec + StartSecondsDec;
                                        string StartSecondsDecStr = String.Format("{0:0.000000}", StartSecondsDec);

                                        EndHourDec = EndHourDec * 3600;
                                        EndMinuteDec = EndMinuteDec * 60;
                                        EndSecondDec = EndHourDec + EndMinuteDec + EndSecondDec;
                                        EndSecondDec = Math.Round(EndSecondDec, 4);
                                        string EndSecondDecStr = String.Format("{0:0.000000}", EndSecondDec);

                                        string newchar = StartSecondsDecStr + ' ' + EndSecondDecStr + ' ' + '0';
                                        newchar.Trim();
                                        line = line.Replace(oldchar, newchar);

                                        writer.WriteLine(line.Trim());
                                    }

                                } // End While

                            } // End StreamReader

                        } // End StreamWriter

                        string SkipfileNameNew = fileNameOld + "_Temp2_Skip_Info.edl";
                        string SkipFileNameTemp2 = EDLFilepath + "\\" + SkipfileNameNew;
                        File.Create(SkipFileNameTemp2).Dispose();

                        using (System.IO.StreamWriter writer_skip = new StreamWriter(SkipFileNameTemp2))
                        {
                            using (System.IO.StreamReader reader_skip = new StreamReader(newFile_temp))
                            {
                                using (System.IO.StreamReader reader_edl = new StreamReader(EDLFileName))
                                {
                                    while (!reader_edl.EndOfStream)
                                    {
                                        string line = reader_edl.ReadLine();
                                        writer_skip.WriteLine(line.Trim());
                                    }

                                    reader_edl.Close();

                                }

                                while (!reader_skip.EndOfStream)
                                {
                                    string line = reader_skip.ReadLine();
                                    writer_skip.WriteLine(line.Trim());
                                }

                            }

                        }

                        string SkipfileNameNew2 = fileNameOld + "_Skip_Info.edl";
                        string SkipFileNamePerm = EDLFilepath + "\\" + SkipfileNameNew2;
                        File.Create(SkipFileNamePerm).Dispose();
                        using (System.IO.StreamWriter writer_skip_array = new StreamWriter(SkipFileNamePerm))
                        {
                            using (System.IO.StreamReader reader_skip_array = new StreamReader(newFile_temp))
                            {
                                string[] lines = File.ReadAllLines(SkipFileNameTemp2);

                                NumericComparer ns = new NumericComparer();
                                Array.Sort(lines, ns);
                                //NumericalSort(lines);

                                foreach (var line in lines) writer_skip_array.WriteLine(line.Trim());
                            }

                            File.Delete(newFile_temp);
                            File.Delete(SkipFileNameTemp2);

                        }

                    } // End IF

                } // End IF

                MessageBox.Show("Completed! HAVE FUN WATCHING YOUR MOVIE!");
            }
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }
        }

        private void CreateBatFile_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Select EDL File.");

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Select EDL File";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "edl";
                openFileDialog1.Filter = "EDL files (*.edl)(*.txt)|*.edl|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string EDL = openFileDialog1.FileName;

                    MessageBox.Show("Select Movie file.");

                    OpenFileDialog openFileDialog2 = new OpenFileDialog();

                    openFileDialog1.InitialDirectory = @"C:\";
                    openFileDialog1.Title = "Select Movie File";

                    openFileDialog1.CheckFileExists = true;
                    openFileDialog1.CheckPathExists = true;

                    openFileDialog1.DefaultExt = "mp4";
                    openFileDialog1.Filter = "Movie files (*.mp4)(*.avi)|*.mp4|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 2;
                    openFileDialog1.RestoreDirectory = true;

                    openFileDialog1.ReadOnlyChecked = true;
                    openFileDialog1.ShowReadOnly = true;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string Movie;
                        Movie = openFileDialog1.FileName;

                        string EDLpath = Path.GetDirectoryName(EDL);
                        string Moviepath = Path.GetDirectoryName(Movie);
                        string MovieName = Path.GetFileNameWithoutExtension(Movie);
                        string fileNameBat = MovieName + "_WATCH_EDITED_MOVIE.bat";
                        string newFile = Moviepath + "\\" + fileNameBat;
                        File.Create(newFile).Dispose();
                        string writerBat = "start \"\" \"C:\\MPlayer\\mplayer.exe\" -edl \"" + EDL + "\"  \"" + Movie + "\"";
                        using (System.IO.StreamWriter writer = new StreamWriter(newFile))
                        {
                            writer.WriteLine(writerBat);
                        }
                    }

                    MessageBox.Show("Completed! HAVE FUN WATCHING YOUR MOVIE!");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }
        }

        private void EXIT_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        public static void NumericalSort(string[] ar)
        {
            Regex rgx = new Regex("([^0-9]*)([0-9]+)");
            Array.Sort(ar, (a, b) =>
            {
                var ma = rgx.Matches(a);
                var mb = rgx.Matches(b);
                for (int i = 0; i < ma.Count; ++i)
                {
                    int ret = ma[i].Groups[1].Value.CompareTo(mb[i].Groups[1].Value);
                    if (ret != 0)
                        return ret;

                    ret = int.Parse(ma[i].Groups[2].Value) - int.Parse(mb[i].Groups[2].Value);
                    if (ret != 0)
                        return ret;
                }

                return 0;
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public class StringLogicalComparer
        {
            public static int Compare(string s1, string s2)
            {
                //get rid of special cases
                if ((s1 == null) && (s2 == null)) return 0;
                else if (s1 == null) return -1;
                else if (s2 == null) return 1;

                if ((s1.Equals(string.Empty) && (s2.Equals(string.Empty)))) return 0;
                else if (s1.Equals(string.Empty)) return -1;
                else if (s2.Equals(string.Empty)) return -1;

                //WE style, special case
                bool sp1 = Char.IsLetterOrDigit(s1, 0);
                bool sp2 = Char.IsLetterOrDigit(s2, 0);
                if (sp1 && !sp2) return 1;
                if (!sp1 && sp2) return -1;

                int i1 = 0, i2 = 0; //current index
                int r = 0; // temp result
                while (true)
                {
                    bool c1 = Char.IsDigit(s1, i1);
                    bool c2 = Char.IsDigit(s2, i2);
                    if (!c1 && !c2)
                    {
                        bool letter1 = Char.IsLetter(s1, i1);
                        bool letter2 = Char.IsLetter(s2, i2);
                        if ((letter1 && letter2) || (!letter1 && !letter2))
                        {
                            if (letter1 && letter2)
                            {
                                r = Char.ToLower(s1[i1]).CompareTo(Char.ToLower(s2[i2]));
                            }
                            else
                            {
                                r = s1[i1].CompareTo(s2[i2]);
                            }
                            if (r != 0) return r;
                        }
                        else if (!letter1 && letter2) return -1;
                        else if (letter1 && !letter2) return 1;
                    }
                    else if (c1 && c2)
                    {
                        r = CompareNum(s1, ref i1, s2, ref i2);
                        if (r != 0) return r;
                    }
                    else if (c1)
                    {
                        return -1;
                    }
                    else if (c2)
                    {
                        return 1;
                    }
                    i1++;
                    i2++;
                    if ((i1 >= s1.Length) && (i2 >= s2.Length))
                    {
                        return 0;
                    }
                    else if (i1 >= s1.Length)
                    {
                        return -1;
                    }
                    else if (i2 >= s2.Length)
                    {
                        return -1;
                    }
                }
            }
        }

        private static int CompareNum(string s1, ref int i1, string s2, ref int i2)
        {
            int nzStart1 = i1, nzStart2 = i2; // nz = non zero
            int end1 = i1, end2 = i2;

            ScanNumEnd(s1, i1, ref end1, ref nzStart1);
            ScanNumEnd(s2, i2, ref end2, ref nzStart2);
            int start1 = i1; i1 = end1 - 1;
            int start2 = i2; i2 = end2 - 1;

            int nzLength1 = end1 - nzStart1;
            int nzLength2 = end2 - nzStart2;

            if (nzLength1 < nzLength2) return -1;
            else if (nzLength1 > nzLength2) return 1;

            for (int j1 = nzStart1, j2 = nzStart2; j1 <= i1; j1++, j2++)
            {
                int r = s1[j1].CompareTo(s2[j2]);
                if (r != 0) return r;
            }
            // the nz parts are equal
            int length1 = end1 - start1;
            int length2 = end2 - start2;
            if (length1 == length2) return 0;
            if (length1 > length2) return -1;
            return 1;
        }

        private static void ScanNumEnd(string s, int start, ref int end, ref int nzStart)
        {
            nzStart = start;
            end = start;
            bool countZeros = true;
            while (Char.IsDigit(s, end))
            {
                if (countZeros && s[end].Equals('0'))
                {
                    nzStart++;
                }
                else countZeros = false;
                end++;
                if (end >= s.Length) break;
            }
        }

        public class NumericComparer : IComparer
        {
            public NumericComparer()
            { }

            public int Compare(object x, object y)
            {
                if ((x is string) && (y is string))
                {
                    return StringLogicalComparer.Compare((string)x, (string)y);
                }
                return -1;
            }
        }

        private void btnChgTime_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                MessageBox.Show("Select EDL file that you would like to change the time.");

                openFileDialog1.InitialDirectory = @"I:\Family\Downloads\Movies";
                openFileDialog1.Title = "Select EDL File";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "edl";
                openFileDialog1.Filter = "All files (*.*)|*.*|EDL files (*.edl)|*.edl";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string TimeChgFileName = openFileDialog1.FileName;
                    string TimeChgPath = Path.GetDirectoryName(TimeChgFileName);
                    string fileNameOld = Path.GetFileNameWithoutExtension(TimeChgFileName);
                    string fileNameNew = TimeChgPath + "\\" + fileNameOld + ".edl";
                    string newFile_temp = TimeChgPath + "\\" + fileNameNew;
                    string fileNametemp1 = TimeChgPath + "\\" + fileNameOld + "_temp1";
                    
                    File.Create(fileNametemp1).Dispose();

                    // Pattern to check each line
                    Regex pattern1 = new Regex(@"(?:[0-99999]).[0-9][0-9][0-9][0-9][0-9][0-9]");


                    using (System.IO.StreamWriter writer = new StreamWriter(fileNametemp1))
                    {
                        using (System.IO.StreamReader reader = new StreamReader(TimeChgFileName))
                        {
                            // Iterate through lines
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                var matches = pattern1.Matches(line);

                                if (matches.Count == 2)
                                {
                                    string oldchar = line;
                                    oldchar = oldchar.Trim();

                                    int length = oldchar.Length;

                                    string Start = "";
                                    string End = "";
                                    string lastPart = "";

                                    if (length == 21)
                                    {
                                        Start = oldchar.Substring(0, 9);
                                        End = oldchar.Substring(10, 9);
                                        lastPart = oldchar.Substring(20, 1);
                                    }

                                    if (length == 22)
                                    {
                                        Start = oldchar.Substring(0, 9);
                                        End = oldchar.Substring(10, 10);
                                        lastPart = oldchar.Substring(21, 1);
                                    }

                                    if (length == 23)
                                    {
                                        Start = oldchar.Substring(0, 10);
                                        End = oldchar.Substring(11, 10);
                                        lastPart = oldchar.Substring(22, 1);
                                    }

                                    if (length == 24)
                                    {
                                        Start = oldchar.Substring(0, 10);
                                        End = oldchar.Substring(11, 11);
                                        lastPart = oldchar.Substring(23, 1);
                                    }

                                    if (length == 25)
                                    {
                                        Start = oldchar.Substring(0, 11);
                                        End = oldchar.Substring(12, 11);
                                        lastPart = oldchar.Substring(24, 1);
                                    }

                                    decimal StartDec = Convert.ToDecimal(Start);
                                    decimal EndDec = Convert.ToDecimal(End);
                                    decimal lastPartDec = Convert.ToDecimal(lastPart);
                                    decimal DecTimeChgTxtBx = Convert.ToDecimal(textBox1.Text);


                                    // Need to see if START or STOP was selected
                                    if (checkBoxStart != null && checkBoxStart.Checked)
                                    {
                                        StartDec = StartDec + DecTimeChgTxtBx;
                                    }

                                    if (checkBoxEnd != null && checkBoxEnd.Checked)
                                    {
                                        EndDec = EndDec + DecTimeChgTxtBx;
                                    }

                                    string StartDecStr = String.Format("{0:0.000000}", StartDec);
                                    StartDecStr.Trim();

                                    string EndDecStr = String.Format("{0:0.000000}", EndDec);

                                    string newchar = StartDecStr + ' ' + EndDecStr + ' ' + lastPart;
                                    newchar.Trim();
                                    line = line.Replace(oldchar, newchar);
                                    line.Trim();

                                    writer.WriteLine(line.Trim());

                                }

                            }
                            reader.Close();
                            reader.Dispose();
                            reader.DiscardBufferedData();
                        }
                        writer.Close();
                        writer.Dispose();
                    }
                    File.Delete(TimeChgFileName);
                    File.Create(fileNameNew).Dispose();

                    // Sort times in chronological order
                    using (System.IO.StreamWriter writer_skip_array = new StreamWriter(fileNameNew))
                    {
                        using (System.IO.StreamReader reader_skip_array = new StreamReader(fileNametemp1))
                        {
                            string[] lines = File.ReadAllLines(fileNametemp1);

                            NumericComparer ns = new NumericComparer();
                            Array.Sort(lines, ns);

                            foreach (var line in lines) writer_skip_array.WriteLine(line.Trim());
                            reader_skip_array.Close();
                            reader_skip_array.Dispose();
                            reader_skip_array.DiscardBufferedData();
                        }
                        writer_skip_array.Close();
                        writer_skip_array.Dispose();                        
                    }
                    File.Delete(fileNametemp1);


                }


                MessageBox.Show("Completed! HAVE FUN WATCHING YOUR MOVIE!");
            }
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // User chooses SRT file
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = @"I:\Family\Downloads\Movies";
                openFileDialog1.Title = "Select SRT File to scan";

                openFileDialog1.CheckFileExists = true;
                openFileDialog1.CheckPathExists = true;

                openFileDialog1.DefaultExt = "srt";
                openFileDialog1.Filter = "All files (*.*)|*.*|SRT files (*.srt)|*.srt";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                openFileDialog1.ReadOnlyChecked = true;
                openFileDialog1.ShowReadOnly = true;


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    string path = Path.GetDirectoryName(fileName);
                    string fileNameOld = Path.GetFileNameWithoutExtension(fileName);
                    string fileNametemp1 = path + "\\" + fileNameOld + "_temp1";
                    string newFile = path + "\\" + fileNameOld + ".edl";
                    string duplicatetemp = path + "\\" + fileNameOld + "_dup_temp";
                    File.Create(fileNametemp1).Dispose();
                    File.Create(newFile).Dispose();
                    File.Create(duplicatetemp).Dispose();

                    using (System.IO.StreamWriter writer = new StreamWriter(fileNametemp1))
                    {
                        using (System.IO.StreamReader read_srt_file = new StreamReader(fileName))
                        {
                            // Read SRT file into an array. Must be an array since we will need to go backwards to the time on a successful word hit.
                            var linecount = File.ReadAllLines(fileName).Count();
                            int count = 0;
                            string[,] srt_array = new string[linecount, 2];

                            while (!read_srt_file.EndOfStream)
                            {                                
                                string srt_file_line = read_srt_file.ReadLine();
                                string count_strng = Convert.ToString(count);
                                srt_array[count, 0] = count_strng;
                                srt_array[count, 1] = srt_file_line;
                                count++;

                            }

                            using (System.IO.StreamReader read_bad_word_list = new StreamReader("C:\\EDLMaker\\bad_word_list.txt"))
                            {
                                List<string> list1 = new List<string>(); 
                               
                                // Load the next bad word into variable
                                while (!read_bad_word_list.EndOfStream)
                                {
                                    string bad_word = read_bad_word_list.ReadLine();
                                    Regex rgx_bad_word = new Regex(bad_word);

                                    // Iterate through SRT_Array for the bad word
                                    for (int row = 0; row < srt_array.GetLength(0); row++)
                                    {
                                        string srt_array_line = srt_array[row, 1];
                                        var matches = Regex.Matches(srt_array_line, @"\b" + bad_word + @"\b", RegexOptions.IgnoreCase);

                                        if (matches.Count >= 1)
                                        {
                                            // Go backwards until time is found
                                            Regex rgx_time = new Regex(@"(?:[0-3]):[0-5][0-9]:[0-5][0-9],[0-9][0-9][0-9]");
                                            int k = row - 1;
                                            string success = "";
                                            while (success != "true")
                                            {
                                                string test_for_time = srt_array[k, 1];
                                                var match_time = rgx_time.Matches(test_for_time);
                                                if (match_time.Count == 2)
                                                {
                                                    // Convert time to seconds and Mplayer EDL format
                                                    string oldchar = test_for_time;
                                                    oldchar = oldchar.Trim();
                                                    string Start = oldchar.Substring(1, 11);
                                                    string End = oldchar.Substring(18, 11);
                                                    Start = Start.Replace(',', '.');
                                                    End = End.Replace(',', '.');

                                                    string StartHour = Start.Substring(0, 1);
                                                    string StartMinute = Start.Substring(2, 2);
                                                    string StartSecond = Start.Substring(5, 6);
                                                    string EndHour = End.Substring(0, 1);
                                                    string EndMinute = End.Substring(2, 2);
                                                    string EndSecond = End.Substring(5, 6);

                                                    decimal StartHourDec = Convert.ToDecimal(StartHour);
                                                    decimal StartMinuteDec = Convert.ToDecimal(StartMinute);
                                                    decimal StartSecondsDec = Convert.ToDecimal(StartSecond);
                                                    decimal EndHourDec = Convert.ToDecimal(EndHour);
                                                    decimal EndMinuteDec = Convert.ToDecimal(EndMinute);
                                                    decimal EndSecondDec = Convert.ToDecimal(EndSecond);

                                                    StartHourDec = StartHourDec * 3600;
                                                    StartMinuteDec = StartMinuteDec * 60;
                                                    StartSecondsDec = StartHourDec + StartMinuteDec + StartSecondsDec;
                                                    string StartSecondsDecStr = String.Format("{0:0.000000}", StartSecondsDec);
                                                    StartSecondsDecStr.Trim();

                                                    EndHourDec = EndHourDec * 3600;
                                                    EndMinuteDec = EndMinuteDec * 60;
                                                    EndSecondDec = EndHourDec + EndMinuteDec + EndSecondDec;
                                                    EndSecondDec = Math.Round(EndSecondDec, 4);
                                                    string EndSecondDecStr = String.Format("{0:0.000000}", EndSecondDec);

                                                    string newchar = StartSecondsDecStr + ' ' + EndSecondDecStr + ' ' + '1';
                                                    newchar.Trim();
                                                    test_for_time = test_for_time.Replace(oldchar, newchar);
                                                    test_for_time.Trim();

                                                    list1.Add(test_for_time);
                                                    success = "true";
                                                }
                                                k--;
                                            }
                                        }
                                    }
                                }
                                List<string> list2 = list1.Distinct().ToList();
                                foreach (string value in list2)
                                {
                                    writer.WriteLine(value.Trim());
                                }

                                read_bad_word_list.Close();
                                read_bad_word_list.Dispose();
                                read_bad_word_list.DiscardBufferedData();
                            }
                            read_srt_file.Close();
                            read_srt_file.Dispose();
                            read_srt_file.DiscardBufferedData();
                        }
                        writer.Close();
                        writer.Dispose();
                    }

                    // Sort times in chronological order
                    using (System.IO.StreamWriter writer_skip_array = new StreamWriter(newFile))
                    {
                        using (System.IO.StreamReader reader_skip_array = new StreamReader(fileNametemp1))
                        {
                            string[] lines = File.ReadAllLines(fileNametemp1);

                            NumericComparer ns = new NumericComparer();
                            Array.Sort(lines, ns);

                            foreach (var line in lines) writer_skip_array.WriteLine(line.Trim());
                            reader_skip_array.Close();
                            reader_skip_array.Dispose();
                            reader_skip_array.DiscardBufferedData();
                        }
                        writer_skip_array.Close();
                        writer_skip_array.Dispose();
                    }
                    File.Delete(fileNametemp1);
                    File.Delete(duplicatetemp);
                }
                MessageBox.Show("Completed EDL creation from SRT! HAVE FUN WATCHING YOUR MOVIE!");
            }       
            catch (Exception error)
            {
                Console.WriteLine("{0} Exception caught.", error);
            }    
        }

        public string content { get; set; }
    }
}
    

