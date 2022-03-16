
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FolderCrawler
{
    public partial class Form1 : Form
    {
        Boolean validFolder;
        Boolean selectedMethod;
        string startDir;
        folder startFolder;
        public Form1()
        {
            validFolder = false;
            selectedMethod = false;
            startFolder = new folder();
            InitializeComponent();
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                label2.Text = fd.SelectedPath;
                validFolder = true;
                startDir = fd.SelectedPath;
            }
            else
            {
                label2.Text = "None Selected";
                validFolder = false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (validFolder)
            {
                label3.ForeColor = Color.Black;
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    startFolder.setCurDir(startDir);
                    startFolder.setEndFile(textBox1.Text);
                    if (BFS_optButton.Checked)
                    {
                        
                        if (startFolder.BFS())
                        {
                            label3.Text = startFolder.getFoundDir();
                        }
                        else
                        {
                            label3.Text = "File Not Found";
                        }
                    }
                    else
                    {
                        if (startFolder.DFS())
                        {
                            label3.Text = startFolder.getFoundDir();
                        }
               
                        else
                        {
                            label3.Text = "File Not Found";
                        }
                    }

                }
                
            }

            else if (!validFolder)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Folder Invalid!";
            }
            else
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Search Mode Must be Selected!";
            }
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            graph.AddEdge("A", "B");
            viewer.Graph = graph;
            graphPanel.SuspendLayout();
            viewer.Dock = DockStyle.Fill;
            graphPanel.Controls.Add(viewer);
            graphPanel.ResumeLayout();
            graphPanel.Show();
        }
    }
}