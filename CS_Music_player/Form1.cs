using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_Music_player
{
    public partial class MusicPlayer : Form
    {

        // to control top panel
        Point _tagPoint;
        bool bMove;
        // create Global Var of string type array to save the titles of the Tracks and path of the track
        String[] paths, files;

        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // code to select Song
            OpenFileDialog ofd = new OpenFileDialog();

            // code to select multiple files
            ofd.Multiselect = true;

            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;      // Save the names of the track in files array
                paths = ofd.FileNames;          // sace the paths of the tracks in path array
                
                // display the music titles in listbox

                for(int i=0;i<files.Length;i++)
                {
                    SongListBox.Items.Add(files[i]); // display songs in listbox
                }
            }
        }

        private void Footer_Click(object sender, EventArgs e)
        {

        }

        private void SongListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // code to play music of media player
            axWindowsMediaPlayer1.URL = paths[SongListBox.SelectedIndex];
        }


        private void TopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            // when mouse down, this window move
            bMove = true;

            // when mouse down, this window's location is saved
            _tagPoint = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            // when mouse up, to be not move
            bMove = false;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            // when mouse down and it is left mouse botton
            if (bMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                Location = new Point(this.Left - (_tagPoint.X - e.X), this.Top - (_tagPoint.Y - e.Y));
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            // Code to close windows
            this.Close();
        }
    }
}
