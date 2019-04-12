using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatSwapper
{
    public partial class bitrate : Form
    {
        bool isGoodClosed = false;
        public bitrate()
        {
            InitializeComponent();
        }

        private void Bit96_CheckedChanged(object sender, EventArgs e)
        {
            BeatSwapper.mp3Bitrate = 96000;
        }

        private void Bit128_CheckedChanged(object sender, EventArgs e)
        {
            BeatSwapper.mp3Bitrate = 128000;
        }

        private void Bit192_CheckedChanged(object sender, EventArgs e)
        {
            BeatSwapper.mp3Bitrate = 192000;
        }

        private void Bit256_CheckedChanged(object sender, EventArgs e)
        {
            BeatSwapper.mp3Bitrate = 256000;
        }

        private void Bit320_CheckedChanged(object sender, EventArgs e)
        {
            BeatSwapper.mp3Bitrate = 320000;
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            isGoodClosed = true;
            Close();
        }

        private void Bitrate_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isGoodClosed) DialogResult = DialogResult.OK;
        }
    }
}
