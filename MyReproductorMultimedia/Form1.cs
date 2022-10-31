using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CREADO POR SAMUEL LOPEZ

namespace MyReproductorMultimedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = LbListaArchivos.SelectedItem as MediaFile;
            if(file != null)
            {
                mpMediaPlayer.URL = file.Path;
                mpMediaPlayer.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Multiselect = true, ValidateNames = true, 
                    Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"
            })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> file = new List<MediaFile>();
                    foreach(string FileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(FileName);
                        file.Add(new MediaFile()
                        {
                            FileName =
                            Path.GetFileNameWithoutExtension(fi.FullName),
                            Path = fi.FullName
                        });
                    }
                    LbListaArchivos.DataSource = file;
                }
            }   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LbListaArchivos.ValueMember = "Path";
            LbListaArchivos.DisplayMember = "FileName";
        }
    }
}
