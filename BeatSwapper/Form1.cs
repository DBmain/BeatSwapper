using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace BeatSwapper
{
    public partial class BeatSwapper : Form
    {
        byte[] originalFile;
        byte[] swappedFile;
        SoundPlayer preview;

        string freq;
        byte bitDepth;
        byte channels;
        int bytesPerSecond;

        public BeatSwapper()
        {
            InitializeComponent();
        }

        void enableButtons(bool what)
        {
            oneCh.Enabled = what;
            twoCh.Enabled = what;
            threeCh.Enabled = what;
            fourCh.Enabled = what;
            fiveCh.Enabled = what;
            sixCh.Enabled = what;
            eightBit.Enabled = what;
            DimaBachilo.Enabled = what;
            twentyFourBit.Enabled = what;
            thirtyTwoBit.Enabled = what;
            textBox2.Enabled = what;
            eightKhz.Enabled = what;
            twelweKhz.Enabled = what;
            elevenKhz.Enabled = what;
            twentyTwoKhz.Enabled = what;
            twentyFourKhz.Enabled = what;
            fourtyFourKhz.Enabled = what;
            fourtyEightKhz.Enabled = what;
            eightyEightKhz.Enabled = what;
            ninetySixKhz.Enabled = what;
            oneSevenSixKhz.Enabled = what;
            oneNineTwoKhz.Enabled = what;
            threeFourEightKhz.Enabled = what;
        }

        void reworkFile()
        {
            bytesPerSecond = channels * bitDepth * Convert.ToInt32(freq) / 8;
            char[] bpsTemp = bytesPerSecond.ToString("X8").ToCharArray();
            byte[] bps = LEtoDecChar(bpsTemp);
            for (int i = 0; i < 4; i++)
            {
                originalFile[i + 28] = bps[i];
            }
            originalFile[22] = channels;
            originalFile[34] = bitDepth;
            char[] freqTemp = Convert.ToInt32(freq).ToString("X8").ToCharArray();
            byte[] freqOutput = LEtoDecChar(freqTemp);
            for(int i = 0; i < 4; i++)
            {
                originalFile[i + 24] = freqOutput[i];
            }
            originalFile[32] = Convert.ToByte((bitDepth * channels) / 8);
            return;
        }

        static string LEtoDecByte(byte[] littleEndian)
        {
            string leStr = "";
            for(int i = 0; i < 4; i++)
            {
                leStr = leStr + littleEndian[i].ToString("X2");
            }
            char[] leCharOrig = leStr.ToCharArray();
            char[] leCharFin = new char[8];
            int o = 7;
            for (int i = 0; i < 8; i += 2)
            {
                leCharFin[i] = leCharOrig[o - 1];
                if (i < 7) leCharFin[i + 1] = leCharOrig[o];
                o -= 2;
            }
            return int.Parse(new string(leCharFin), System.Globalization.NumberStyles.HexNumber).ToString();
        }

        static byte[] LEtoDecChar(char[] input)
        {
            byte[] output = new byte[4];
            char[] temp = new char[8];
            byte o = 7;
            for (int i = 0; i < 8; i += 2)
            {
                temp[i] = input[o - 1];
                if (i < 7) temp[i + 1] = input[o];
                o -= 2;
            }
            byte d = 0;
            for (o = 0; o < 7; o += 2)
            {
                output[d] = byte.Parse(temp[o].ToString() + temp[o + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                d++;
            }
            return output;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                stopPreview_Click(sender, e);
                originalFile = File.ReadAllBytes(openFileDialog1.FileName);
                channels = originalFile[22];
                switch(channels)
                {
                    case 1:
                        oneCh.Checked = true;
                        break;
                    case 2:
                        twoCh.Checked = true;
                        break;
                    case 3:
                        threeCh.Checked = true;
                        break;
                    case 4:
                        fourCh.Checked = true;
                        break;
                    case 5:
                        fiveCh.Checked = true;
                        break;
                    case 6:
                        sixCh.Checked = true;
                        break;
                    default:
                        MessageBox.Show("Invalid WAV file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                }
                bitDepth = originalFile[34];
                switch (bitDepth)
                {
                    case 8:
                        eightBit.Checked = true;
                        break;
                    case 16:
                        DimaBachilo.Checked = true;
                        break;
                    case 24:
                        twentyFourBit.Checked = true;
                        break;
                    case 32:
                        thirtyTwoBit.Checked = true;
                        break;
                    default:
                        MessageBox.Show("Invalid WAV file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                }
                byte[] frequency = new byte[4];
                for(int i = 0; i < 4; i++)
                {
                    frequency[i] = originalFile[i + 24];
                }
                textBox1.Text = openFileDialog1.FileName;
                freq = LEtoDecByte(frequency);
                textBox2.Text = freq;
                enableButtons(true);
                checkBox1.Enabled = true;
                previewButton.Enabled = true;
                saveButton.Enabled = true;
                checkBox1.Checked = false;
                swappedFile = null;
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            reworkFile();
            if(channels > 2)
            {
                MessageBox.Show("This application can't preview track with 3+ channels! You can only save it!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!checkBox1.Checked)
            {
                using (MemoryStream ms = new MemoryStream(originalFile))
                {
                    preview = new SoundPlayer(ms);
                    preview.Play();
                }
            }
            else
            {
                if(swappedFile == null)
                {
                    MessageBox.Show("You didn't swapped beats!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (MemoryStream ms = new MemoryStream(swappedFile))
                {
                    preview = new SoundPlayer(ms);
                    preview.Play();
                }
                checkBox1.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                textBox3.Enabled = false;
                offsetText.Enabled = false;
                swapButton.Enabled = false;
            }
            stopPreview.Enabled = true;
            previewButton.Enabled = false;
        }

        private void stopPreview_Click(object sender, EventArgs e)
        {
            if(preview != null) preview.Stop();
            if(checkBox1.Checked)
            {
                checkBox1.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                textBox3.Enabled = true;
                offsetText.Enabled = true;
                swapButton.Enabled = true;
            }
            stopPreview.Enabled = false;
            previewButton.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (Convert.ToInt32(textBox2.Text))
                {
                    case 8000:
                        eightKhz.Checked = true;
                        break;
                    case 12000:
                        twelweKhz.Checked = true;
                        break;
                    case 22050:
                        twentyTwoKhz.Checked = true;
                        break;
                    case 24000:
                        twentyFourKhz.Checked = true;
                        break;
                    case 44100:
                        fourtyFourKhz.Checked = true;
                        break;
                    case 4800:
                        fourtyEightKhz.Checked = true;
                        break;
                    case 88200:
                        eightyEightKhz.Checked = true;
                        break;
                    case 176400:
                        oneSevenSixKhz.Checked = true;
                        break;
                    case 192000:
                        oneNineTwoKhz.Checked = true;
                        break;
                    case 384000:
                        threeFourEightKhz.Checked = true;
                        break;
                    default:
                        eightKhz.Checked = false;
                        twelweKhz.Checked = false;
                        twentyTwoKhz.Checked = false;
                        twentyFourKhz.Checked = false;
                        fourtyFourKhz.Checked = false;
                        fourtyEightKhz.Checked = false;
                        eightyEightKhz.Checked = false;
                        oneSevenSixKhz.Checked = false;
                        oneNineTwoKhz.Checked = false;
                        threeFourEightKhz.Checked = false;
                        break;

                }
                freq = textBox2.Text;
            }
            catch
            {
                if (textBox2.Text == "")
                {
                    freq = "0";
                }
                else
                {
                    MessageBox.Show("Your frequency is too big, or something wrong with it! Returning to default!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    freq = "44100";
                }
                textBox2.Text = freq;
            }
        }

        private void eightKhz_CheckedChanged(object sender, EventArgs e)
        {
            if(eightKhz.Checked) textBox2.Text = "8000";
        }

        private void elevenKhz_CheckedChanged(object sender, EventArgs e)
        {
            if(elevenKhz.Checked)textBox2.Text = "11250";
        }

        private void twelweKhz_CheckedChanged(object sender, EventArgs e)
        {
            if(twelweKhz.Checked) textBox2.Text = "12000";
        }

        private void twentyTwoKhz_CheckedChanged(object sender, EventArgs e)
        {
            if(twentyTwoKhz.Checked) textBox2.Text = "22050";
        }

        private void twentyFourKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (twentyFourKhz.Checked) textBox2.Text = "24000";
        }

        private void fourtyFourKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (fourtyFourKhz.Checked) textBox2.Text = "44100";
        }

        private void fourtyEightKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (fourtyEightKhz.Checked) textBox2.Text = "48000";
        }

        private void eightyEightKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (eightyEightKhz.Checked) textBox2.Text = "88200";
        }

        private void ninetySixKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (ninetySixKhz.Checked) textBox2.Text = "96000";
        }

        private void oneSevenSixKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (oneSevenSixKhz.Checked) textBox2.Text = "176000";
        }

        private void oneNineTwoKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (oneNineTwoKhz.Checked) textBox2.Text = "192000";
        }

        private void threeFourEightKhz_CheckedChanged(object sender, EventArgs e)
        {
            if (threeFourEightKhz.Checked) textBox2.Text = "384000";
        }

        private void oneCh_CheckedChanged(object sender, EventArgs e)
        {
            if (oneCh.Checked) channels = 1;
        }

        private void twoCh_CheckedChanged(object sender, EventArgs e)
        {
            if (twoCh.Checked) channels = 2;
        }

        private void threeCh_CheckedChanged(object sender, EventArgs e)
        {
            if (threeCh.Checked) channels = 3;
        }

        private void fourCh_CheckedChanged(object sender, EventArgs e)
        {
            if (fourCh.Checked) channels = 4;
        }

        private void fiveCh_CheckedChanged(object sender, EventArgs e)
        {
            if (fiveCh.Checked) channels = 5;
        }

        private void sixCh_CheckedChanged(object sender, EventArgs e)
        {
            if (sixCh.Checked) channels = 6;
        }

        private void eightBit_CheckedChanged(object sender, EventArgs e)
        {
            if (eightBit.Checked) bitDepth = 8;
        }

        private void DimaBachilo_CheckedChanged(object sender, EventArgs e)
        {
            if (DimaBachilo.Checked) bitDepth = 16;
        }

        private void twentyFourBit_CheckedChanged(object sender, EventArgs e)
        {
            if (twentyFourBit.Checked) bitDepth = 24;
        }

        private void thirtyTwoBit_CheckedChanged(object sender, EventArgs e)
        {
            if (thirtyTwoBit.Checked) bitDepth = 32;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            reworkFile();
            string fileName = null;
            if (checkBox1.Checked)
            {
                int i = 0;
                do
                {
                    if (radioButton1.Checked)
                    {
                        if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_1_3_" + i + Path.GetExtension(textBox1.Text)))
                        {
                            fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_1_3_" + i + Path.GetExtension(textBox1.Text);
                            break;
                        }
                        else i++;
                    }
                    else if (radioButton2.Checked)
                    {
                        if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_2_4_" + i + Path.GetExtension(textBox1.Text)))
                        {
                            fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_2_4_" + i + Path.GetExtension(textBox1.Text);
                            break;
                        }
                        else i++;
                    }
                } while (true);
                //if (radioButton2.Checked) fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_2_4" + Path.GetExtension(textBox1.Text);
                //else if (radioButton1.Checked) fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_swapped_1_3" + Path.GetExtension(textBox1.Text);
            }
            else
            {
                int i = 0;
                do
                {
                    if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + "_" + i + Path.GetExtension(textBox1.Text)))
                    {
                        fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + "_" + i + Path.GetExtension(textBox1.Text);
                        break;
                    }
                    else i++;
                } while (true);
            }
            saveFileDialog1.FileName = fileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                do
                {
                    try
                    {
                        if (!checkBox1.Checked) File.WriteAllBytes(saveFileDialog1.FileName, originalFile);
                        else File.WriteAllBytes(saveFileDialog1.FileName, swappedFile);
                        break;
                    }
                    catch
                    {
                        MessageBox.Show("File is busy! Try again or choose another name!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                } while (true);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                enableButtons(false);
                textBox3.Enabled = true;
                offsetText.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                if (swappedFile == null) saveButton.Enabled = false;
                textBox3_TextChanged(sender, e);
            }
            else
            {
                enableButtons(true);
                textBox3.Enabled = false;
                offsetText.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                swapButton.Enabled = false;
                saveButton.Enabled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            swapButton.Enabled = false;
            checkBox1.Enabled = false;
            saveButton.Enabled = false;
            openButton.Enabled = false;
            offsetText.Enabled = false;
            previewButton.Enabled = false;
            swappedFile = null;
            float bpm = Convert.ToSingle(textBox3.Text);
            reworkFile();
            byte[] dataSizeByte = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                dataSizeByte[i] = originalFile[i + 40];
            }
            int dataSize = Convert.ToInt32(LEtoDecByte(dataSizeByte));
            swappedFile = new byte[originalFile.Length];
            float bps = bpm / 60;
            int swapBytes = Convert.ToInt32((1 / bps) * bytesPerSecond);
            while(true)
            {
                if (swapBytes % (bitDepth * channels / 8) != 0) swapBytes--;
                else break;
            }
            int offset = Convert.ToInt32(Convert.ToSingle(offsetText.Text) * bytesPerSecond);
            int blocks = (dataSize / swapBytes) - 4;
            for (int i = 0; i < 44; i++)
            {
                swappedFile[i] = originalFile[i];
            }
            for(int i = 44; i < offset + 44; i++)
            {
                swappedFile[i] = originalFile[i];
            }
            for (int i = 0; i < blocks - (offset / swapBytes); i += 4)
            {
                if(radioButton1.Checked)
                {
                    for (int r = 44 + offset + (i * swapBytes); r < 44 + offset + swapBytes + (i * swapBytes); r++)
                    {
                        swappedFile[r] = originalFile[r + swapBytes + swapBytes];
                        swappedFile[r + swapBytes + swapBytes] = originalFile[r];   
                        swappedFile[r + swapBytes] = originalFile[r + swapBytes];
                        swappedFile[r + swapBytes + swapBytes + swapBytes] = originalFile[r + swapBytes + swapBytes + swapBytes];
                    }
                }
                else if(radioButton2.Checked)
                {
                    for (int r = 44 + offset + (i * swapBytes); r < 44 + offset + swapBytes + (i * swapBytes); r++)
                    {
                        swappedFile[r + swapBytes] = originalFile[r + swapBytes + swapBytes + swapBytes];
                        swappedFile[r + swapBytes + swapBytes + swapBytes] = originalFile[r + swapBytes];
                        swappedFile[r] = originalFile[r];
                        swappedFile[r + swapBytes + swapBytes] = originalFile[r + swapBytes + swapBytes];
                    }
                }
            }
            for(int i = 44 + offset + (blocks * swapBytes) - ((offset / swapBytes) * swapBytes); i < dataSize + (originalFile.Length - dataSize); i++)
            {
                swappedFile[i] = originalFile[i];
            }
            textBox3.Enabled = true;
            swapButton.Enabled = true;
            checkBox1.Enabled = true;
            offsetText.Enabled = true;
            saveButton.Enabled = true;
            openButton.Enabled = true;
            previewButton.Enabled = true;
            saveButton.Enabled = true;
            //radioButton1.Enabled = true;
            //radioButton2.Enabled = true;            
        }

        private void offsetText_TextChanged(object sender, EventArgs e)
        {
            if (offsetText.Text == "") offsetText.Text = "0";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "") swapButton.Enabled = true;
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BeatSwapper\nWritten by Denis \"DB\" Boyarchuk\nt.me/russkiypoopforever\ngithub.com/DBmain/BeatSwapper", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
