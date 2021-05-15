using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Daugiagijio_trecias_praktinis_darbas
{

    public partial class Form1 : Form
    {
        ManualResetEvent manualResetEvent = new ManualResetEvent(true);
        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;
        private string location = "";
        List<string> arffAttributes = new List<string>();
        List<string> arffData = new List<string>();
        private int progressBarCount = 0;
        private int progressBarCountForCheck = 0;
        private static readonly Object lockToken = new Object();
      //  private string tempString = "";
        private bool exists2 = false;
        List<string> arffListBoxItems;
        List<string> arffCheckedListBoxItems;
        delegate void Runnable();
        int countElements = 0;
        StreamWriter streamWriter;
        List<string> files;
        private bool close = false;
        StringBuilder tempString = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void openFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();

            if (browserDialog.ShowDialog(this) == DialogResult.OK)
                location = browserDialog.SelectedPath;
            arffCheckedListBox.Items.Clear();
            checkLabel.Visible = true;
            progressBarCountForCheck = 0;
            Thread checkThread = new Thread(checkIfFileReliable);
            checkThread.Start();
        }
        private void progressBarCheckValue()
        {
            this.Invoke((Action)delegate
            {
                progressBarForCheck.Minimum = 0;
                // progressBar.Maximum = Directory.GetFiles(location).Length;
                progressBarForCheck.Maximum = files.Count;
                progressBarForCheck.Value = 0;
            });
            while (progressBarForCheck.Maximum != progressBarCountForCheck)
            {
                this.Invoke((Action)delegate
                {
                    if (exists2 == true)
                    {
                        progressBarForCheck.Value = progressBarCountForCheck;
                        exists2 = false;
                    }
                });

            }
        }
        private void checkIfFileReliable()
        {
            files = new List<string>();
            List<string> tempFiles = new List<string>();
            List<string> tempAttributes = new List<string>();
            var firstFile = Directory.GetFiles(location).FirstOrDefault();
            string[] firstFileLenght = File.ReadAllLines(firstFile);

            string data = firstFileLenght[firstFileLenght.Length - 1];
            String[] oneFileArffData = data.Split(',');

            tempFiles = Directory.GetFiles(location).OfType<string>().ToList();

            foreach (string file in tempFiles)
            {
                string[] lines = File.ReadAllLines(file);
                if (lines.Contains("@relation SMILEfeatures") && lines.Contains("@data"))
                    files.Add(file);
            }
            string[] lines2 = File.ReadAllLines(firstFile);
            foreach (string line2 in lines2)
            {
                if (line2.Contains("@attribute"))
                {
                    tempAttributes.Add(line2);
                }
            }
            int i = 0;
            this.Invoke((Action)delegate
            {
                progressBarForCheck.Visible = true;
            });
            Thread checkProgressBar = new Thread(progressBarCheckValue);
            checkProgressBar.Start();
            foreach (string file in files.ToArray())
            {
                progressBarCountForCheck++;
                i++;
                string[] liness = File.ReadAllLines(file);

                string data2 = liness[liness.Length - 1];
                String[] oneFileArffData2 = data2.Split(',');

                if (liness.Length != firstFileLenght.Length)
                    files.Remove(file);

                if (oneFileArffData.Length != oneFileArffData2.Length)
                    files.Remove(file);

                    Console.WriteLine(i);
                exists2 = true;
            }
            Thread.Sleep(700);
            Thread addingAttributesThread = new Thread(addingAttributes);
            addingAttributesThread.Start();
            this.Invoke((Action)delegate
            {
                checkLabel.Visible = false;
                progressBarForCheck.Visible = false;
                progressBarForCheck.Value = 0;
            });
        }
        private void addingAttributes()
        {
            // var file = Directory.GetFiles(location, "*.*").FirstOrDefault();
            var firstFile = files.FirstOrDefault();
            string[] lines2 = File.ReadAllLines(firstFile);
            foreach (string line2 in lines2)
                if (line2.Contains("@attribute"))
                {
                    this.Invoke((Action)delegate
                    {
                        arffCheckedListBox.Items.Add(line2);
                    });
                }
            this.Invoke((Action)delegate
            {
                combineButton.Enabled = true;
                checkAllButton.Visible = true;
                uncheckAllButton.Visible = true;
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arffCheckedListBox.Items.Count; i++)
            {
                arffCheckedListBox.SetItemChecked(i, true);
            }
        }

        private void uncheckAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arffCheckedListBox.Items.Count; i++)
            {
                arffCheckedListBox.SetItemChecked(i, false);
            }
        }

        private void saveToFileOnce()
        {
            string fileText = "@relation SMILEfeatures\n\n";
            foreach (string arffAttribute in arffAttributes)
            {
                fileText += arffAttribute + "\n";
            }
            fileText += "\n@data\n\n";
            File.WriteAllText(@"D:\KOLEGIJOS MEDZIAGA\DAUGIAGIJIS PROGRAMAVIMAS\Daugiagijio trecias praktinis darbas\newFile.arff", fileText);
            streamWriter = new StreamWriter(@"D:\KOLEGIJOS MEDZIAGA\DAUGIAGIJIS PROGRAMAVIMAS\Daugiagijio trecias praktinis darbas\newFile.arff", true);
        }
        private void combineButton_Click(object sender, EventArgs e)
        {
            close = true;
            checkAllButton.Visible = false;
            uncheckAllButton.Visible = false;
            combineButton.Enabled = false;
            pauseButton.Enabled = true;
            continueButton.Enabled = true;
            cancelButton.Enabled = true;
            arffAttributes = new List<string>();
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
            Thread combineThread = new Thread(combine);
            Thread progressBarThread = new Thread(() => progressBarValue(combineThread));
            progressBarThread.Start();
            combineThread.Start();

        }
        void combine()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            this.Invoke((Action)delegate
            {
                foreach (string arffValue in arffCheckedListBox.CheckedItems)
                {
                    arffAttributes.Add(arffValue);
                }
                saveToFileOnce();
            });

            countElements = arffAttributes.Count;
            this.Invoke((Action)delegate
            {
                arffListBoxItems = arffCheckedListBox.Items.OfType<string>().ToList();
                arffCheckedListBoxItems = arffCheckedListBox.CheckedItems.OfType<string>().ToList();
            });
            foreach (string file in files)
            {
                progressBarCount++;
                i = 0;
                k = 0;
                string data = "";
                //string temptempString = "";
                string[] lines = File.ReadAllLines(file);
                data = lines[lines.Length - 1];
                String[] oneFileArffData = data.Split(',');


                foreach (string arffValue in arffListBoxItems)
                {
                    i++;
                    if (arffCheckedListBoxItems.Contains(arffValue))
                    {
                        k++;
                        foreach (string thisData in oneFileArffData)
                        {
                            j++;
                            if (i == j)
                            {
                                j = 0;
                                //temptempString += thisData + ",";
                                tempString.Append(thisData + ",");
                                break;
                            }
                        }
                        if (k == countElements)
                            break;
                    }
                }
                // temptempString = temptempString.Substring(0, temptempString.Length - 1);
                //   tempString += temptempString + Environment.NewLine;
                tempString.Append(Environment.NewLine);
                //exists = true;

               // temptempString = "";
                manualResetEvent.WaitOne();
                if (cancellationToken.IsCancellationRequested)
                {
                    arffListBoxItems = null;
                    arffCheckedListBoxItems = null;
                    streamWriter.Close();
                    File.Delete("D:\\KOLEGIJOS MEDZIAGA\\DAUGIAGIJIS PROGRAMAVIMAS\\Daugiagijio trecias praktinis darbas\\newFile.arff");
                    progressBarCount = 0;
                    //tempString = "";
                    tempString.Remove(0, tempString.Length);
                    this.Invoke((Action)delegate
                    {
                        arffCheckedListBox.Items.Clear();
                        MessageBox.Show("Combining is cancelled");
                        combineButton.Enabled = false;
                        pauseButton.Enabled = false;
                        cancelButton.Enabled = false;
                        continueButton.Enabled = false;
                    });
                    break;
                }

            }
        }
        private void progressBarValue(Thread thread)
        {
            progressBarSettings();
            while (true)
            {

                this.Invoke((Action)delegate
                {
                    progressBar.Value = progressBarCount;
                });

                //this.Invoke((Action)delegate
                //{
                //    if (exists == true)
                //    {
                //        if (!cancellationToken.IsCancellationRequested)
                //            streamWriter.WriteLine(tempString);
                //        exists = false;
                //    }
                //});

                if (!thread.IsAlive)
                {
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        streamWriter.WriteLine(tempString);
                        arffListBoxItems = null;
                        arffCheckedListBoxItems = null;
                        streamWriter.Close();
                        Thread.Sleep(700);
                        this.Invoke((Action)delegate { MessageBox.Show("Done"); });
                        this.Invoke((Action)delegate
                        {
                            tempString.Remove(0, tempString.Length);
                            progressBarCount = 0;
                            progressBar.Value = 0;
                            arffCheckedListBox.Items.Clear();
                            combineButton.Enabled = false;
                            pauseButton.Enabled = false;
                            cancelButton.Enabled = false;
                            continueButton.Enabled = false;
                            close = false;
                        });
                    }
                    break;
                }
            }
        }

        private void progressBarSettings()
        {
            this.Invoke((Action)delegate
            {
                progressBar.Minimum = 0;
                // progressBar.Maximum = Directory.GetFiles(location).Length;
                progressBar.Maximum = files.Count;
                progressBar.Value = 0;
            });
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            manualResetEvent.Reset();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            manualResetEvent.Set();
        }


        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (close == true)
            e.Cancel = true;
        }
    }
}
