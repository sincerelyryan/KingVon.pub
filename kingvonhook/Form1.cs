using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CuoreUI.Components;
using Gma.System.MouseKeyHook;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;


namespace kingvonhook
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;


        }

        public static class paths // yay super paths
        {
            public static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            public static string combined = Path.Combine(path + "\\KingVon.pub");
            public static string misc = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            public static string misc2 = Path.Combine(misc + "cleaner.cmd");
            

        }


        private IKeyboardEvents _globalHook;

        private void Form1_Load(object sender, EventArgs e)
        {
            _globalHook = Hook.GlobalEvents();
            _globalHook.KeyDown += Globalhook_KeyDown;

            


        }

        private void Globalhook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                if (guna2Panel2.Visible == true)
                {
                    guna2Panel2.Visible = false;
                    guna2Panel4.Visible = false;
                    guna2Panel5.Visible = false;
                    guna2Panel6.Visible = false;
                    guna2Button1.Visible = false;
                    guna2Button2.Visible = false;
                    guna2Button3.Visible = false;

                }
                else
                {
                    guna2Panel2.Visible = true;
                    guna2Button1.Visible = true;
                    guna2Button2.Visible = true;
                    guna2Button3.Visible = true;
                    if (guna2Button1.Checked == true)
                    {
                        guna2Panel4.Visible = true;
                    }
                    if (guna2Button2.Checked == true)
                    {
                        guna2Panel5.Visible = true;
                    }
                    if (guna2Button3.Checked == true)
                    {
                        guna2Panel6.Visible = true;
                    }
                }

            }

            if (e.KeyCode == Keys.F1)
            {
                if (guna2HtmlLabel12.Text == "Disabled")
                {
                    guna2HtmlLabel12.Text = "Enabled";
                    guna2HtmlLabel12.ForeColor = Color.MediumAquamarine;
                }
                else
                {
                    guna2HtmlLabel12.Text = "Disabled";
                    guna2HtmlLabel12.ForeColor = Color.FromArgb(232, 53, 84);
                }
            }

            if (e.KeyCode == Keys.F3)
            {


                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }





            }


        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2Button1.Checked == true)
            {
                guna2Panel4.Visible = true;
            }
            else
            {
                guna2Panel4.Visible = false;
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void guna2CustomCheckBox8_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox8.Checked == true)
            {
                Install2v2();
                guna2CustomCheckBox5.Checked = false;
            }

        }

        private void pluginsCheck_Tick(object sender, EventArgs e)
        {
        }

        private void guna2CustomCheckBox5_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox8.Checked == true)
            {

                Install1v1();
                guna2CustomCheckBox5.Checked = true;
                guna2CustomCheckBox8.Checked = false;
            }
        }

        private static void DeletePlugins()
        {
            
            if (Directory.Exists(paths.combined + "\\plugins"))
            {
                Directory.Delete(paths.combined + "\\plugins", true);
            }


        }
        private static void Install2v2()
        {

            DeletePlugins();
            
            Directory.CreateDirectory(paths.combined);
            string twosPlugins = Path.Combine(paths.combined + "\\plugins.zip");
            WebClient wc = new WebClient();
            wc.DownloadFile("https://github.com/sincerelyryan/KingVonBot-Plugins/raw/refs/heads/main/2v2plugins.zip", twosPlugins);
            ZipFile.ExtractToDirectory(twosPlugins, paths.combined);
            File.Delete(twosPlugins);




        }
        private static void Install1v1()
        {

            DeletePlugins();
            Directory.CreateDirectory(paths.combined);
            string twosPlugins = Path.Combine(paths.combined + "\\plugins.zip");
            WebClient wc = new WebClient();
            wc.DownloadFile("https://github.com/sincerelyryan/KingVonBot-Plugins/raw/refs/heads/main/plugins.zip", twosPlugins);
            ZipFile.ExtractToDirectory(twosPlugins, paths.combined);
            File.Delete(twosPlugins);




        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c python -m pip install --upgrade colorama PySide6",
                UseShellExecute = true

            };
            Process.Start(startInfo);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            Process.Start(paths.combined + "\\sparkgui.exe");
            Process.Start(paths.combined + "\\SparklineV0.3.exe");

        }

        private void guna2CustomCheckBox6_Click(object sender, EventArgs e)
        {
            if (guna2CustomCheckBox6.Checked == true)
            {
                cuiFormHideCaptureScreenshot1.TargetForm = this;
            }
            else
            {
                cuiFormHideCaptureScreenshot1.TargetForm = null;
            } 
                

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // OVERLAY TOGGLING
            if (guna2CustomCheckBox1.Checked == true)
            {
                guna2CustomCheckBox2.Visible = true;
                guna2CustomCheckBox4.Visible = true;
                guna2HtmlLabel6.Visible = true;
                guna2HtmlLabel8.Visible = true;
                guna2Panel3.Visible = true;
                if (guna2CustomCheckBox4.Checked == true)
                {
                    pictureBox4.Visible = true;
                }
                else
                {
                    pictureBox4.Visible = false;
                }
            }
            else
            {
                guna2CustomCheckBox2.Visible = false;
                guna2CustomCheckBox4.Visible = false;
                guna2HtmlLabel6.Visible = false;
                guna2HtmlLabel8.Visible = false;
                guna2Panel3.Visible = false;
                pictureBox4.Visible = false;
            }
            guna2Panel1.Visible = guna2CustomCheckBox3.Checked;


            // OVERLAY ELEMENTS

            if (guna2CustomCheckBox2.Checked == true)
            {
                guna2HtmlLabel11.Visible = true;
                guna2HtmlLabel12.Visible = true;

            }
            else
            {
                guna2HtmlLabel11.Visible = false;
                guna2HtmlLabel12.Visible = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2Button2.Checked == true)
            {
                guna2Panel5.Visible = true;
            }
            else
            {
                guna2Panel5.Visible = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2Button3.Checked == true)
            {
                guna2Panel6.Visible = true;
            }
            else
            {
                guna2Panel6.Visible = false;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile("https://github.com/sincerelyryan/KingVonBot-Plugins/raw/refs/heads/main/clean.cmd", paths.misc2);
            Process.Start(paths.misc2).WaitForExit();
            File.Delete(paths.misc2);
        }
    }
}
