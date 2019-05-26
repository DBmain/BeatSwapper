using System;
using System.IO;
using System.Windows.Forms;
using System.Media;
using NAudio;
using NAudio.Wave;
using System.Text;

namespace BeatSwapper
{
    public partial class BeatSwapper : Form
    {
        byte[] originalFile;
        byte[] swappedFile;
        byte[] reversedFile;
        SoundPlayer preview;

        string freq;
        byte bitDepth;
        byte channels;
        int bytesPerSecond;
        int dataStartOffset = 0;
        int dataSize;

        public static int mp3Bitrate;

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
            ref byte[] rework = ref originalFile;
            if (reverse.Checked && !checkBox1.Checked) rework = ref reversedFile;
            else if (checkBox1.Checked && swappedFile != null) rework = ref swappedFile;
            bytesPerSecond = channels * bitDepth * Convert.ToInt32(freq) / 8;
            byte[] bps = BitConverter.GetBytes(bytesPerSecond);
            for (int i = 0; i < 4; i++)
            {
                rework[i + 28] = bps[i];
            }
            rework[22] = channels;
            rework[34] = bitDepth;
            byte[] freqOutput = BitConverter.GetBytes(Convert.ToInt32(freq));
            for(int i = 0; i < 4; i++)
            {
                rework[i + 24] = freqOutput[i];
            }
            rework[32] = Convert.ToByte((bitDepth * channels) / 8);
            return;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                stopPreview_Click(sender, e);
                if(Path.GetExtension(openFileDialog1.FileName).ToLower() == ".wav") originalFile = File.ReadAllBytes(openFileDialog1.FileName);
                else if(Path.GetExtension(openFileDialog1.FileName).ToLower() == ".mp3")
                {
                    using (var reader = new NAudio.Wave.Mp3FileReader(openFileDialog1.FileName))
                    {
                        using (MemoryStream wavCreate = new MemoryStream())
                        {
                            NAudio.Wave.WaveFileWriter.WriteWavFileToStream(wavCreate, reader);
                            originalFile = wavCreate.ToArray();
                        }
                    }
                }
                else if (Path.GetExtension(openFileDialog1.FileName).ToLower() == ".flac")
                {
                    using (var reader = new NAudio.Wave.MediaFoundationReader(openFileDialog1.FileName))
                    {
                        using (MemoryStream wavCreate = new MemoryStream())
                        {
                            NAudio.Wave.WaveFileWriter.WriteWavFileToStream(wavCreate, reader);
                            originalFile = wavCreate.ToArray();
                        }
                    }
                }
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
                        MessageBox.Show("Invalid WAV file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Invalid WAV file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                byte[] frequency = new byte[4];
                for(int i = 0; i < 4; i++)
                {
                    frequency[i] = originalFile[i + 24];
                }
                byte[] dataSizeByte = new byte[4];
                if (originalFile[35] == 0 && originalFile[36] == 100 && originalFile[37] == 97 && originalFile[38] == 116 && originalFile[39] == 97) dataStartOffset = 0;
                else
                {
                    for (int i = 1; i < originalFile.Length - 4; i++)
                    {
                        if (originalFile[35 + i] == 0 && originalFile[36 + i] == 100 && originalFile[37 + i] == 97 && originalFile[38 + i] == 116 && originalFile[39 + i] == 97)
                        {
                            dataStartOffset = i;
                            break;
                        }
                        else continue;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    dataSizeByte[i] = originalFile[i + 40 + dataStartOffset];
                }
                dataSize = BitConverter.ToInt32(dataSizeByte, 0);
                textBox1.Text = openFileDialog1.FileName;
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();
                freq = Convert.ToString(BitConverter.ToInt32(frequency, 0));
                textBox2.Text = freq;
                enableButtons(true);
                checkBox1.Enabled = true;
                previewButton.Enabled = true;
                saveButton.Enabled = true;
                reverse.Enabled = true;
                checkBox1.Checked = false;
                reverse.Checked = false;
                swappedFile = null;
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            ref byte[] playing = ref originalFile;
            if (checkBox1.Checked) playing = ref swappedFile;
            if (!checkBox1.Checked && reverse.Checked) playing = ref reversedFile;
            if (playing == null)
            {
                MessageBox.Show("You didn't swapped beats!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Convert.ToInt32(freq) < 1000)
            {
                MessageBox.Show("Minimal frequency is 1000! Changing it!", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                freq = "1000";
                textBox2.Text = "1000";
            }
            reworkFile();
            if(channels > 2)
            {
                MessageBox.Show("This application can't preview track with 3+ channels! You can only save it!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!checkBox1.Checked && !reverse.Checked)
            {
                checkBox1.Enabled = false;
                reverse.Enabled = false;
            }
            else if(checkBox1.Checked && !reverse.Checked)
            {
                checkBox1.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                textBox3.Enabled = false;
                offsetText.Enabled = false;
                swapButton.Enabled = false;
                reverse.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = false;
                reverse.Enabled = false;
            }
            stopPreview.Enabled = true;
            previewButton.Enabled = false;
            using (MemoryStream ms = new MemoryStream(playing))
            {
                preview = new SoundPlayer(ms);
                preview.Play();
            }
        }

        private void stopPreview_Click(object sender, EventArgs e)
        {
            if(preview != null) preview.Stop();
            if(checkBox1.Checked && !reverse.Checked)
            {
                checkBox1.Enabled = true;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                textBox3.Enabled = true;
                offsetText.Enabled = true;
                swapButton.Enabled = true;
                reverse.Enabled = true;
            }
            else if(!checkBox1.Checked && !reverse.Checked)
            {
                checkBox1.Enabled = true;
                reverse.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = true;
                reverse.Enabled = true;
            }
            stopPreview.Enabled = false;
            previewButton.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if(textBox2.Text != "") if (Convert.ToInt32(textBox2.Text) > 999999) textBox2.Text = "999999";
            try
            {
                if (Convert.ToInt32(textBox2.Text) > 999999) textBox2.Text = "999999";
                //if (Convert.ToInt32(textBox2.Text) < 1000) textBox2.Text = "999999";
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
                    case 48000:
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
                    freq = "1000";
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
            if (oneSevenSixKhz.Checked) textBox2.Text = "176400";
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
            ref byte[] write = ref originalFile;
            string reversedName = null;
            if (reverse.Checked) reversedName = "_reversed";
            if (reverse.Checked && !checkBox1.Checked) write = ref reversedFile;
            if (checkBox1.Checked) write = swappedFile;
            string fileName = null;
            if (Path.GetExtension(textBox1.Text).ToLower() == ".wav" || Path.GetExtension(textBox1.Text).ToLower() == ".flac") saveFileDialog1.FilterIndex = 1;
            else if (Path.GetExtension(textBox1.Text).ToLower() == ".mp3") saveFileDialog1.FilterIndex = 2;
            string extension = Path.GetExtension(textBox1.Text);
            saveFileDialog1.InitialDirectory = Path.GetDirectoryName(textBox1.Text);
            if (extension == ".flac") extension = ".wav";
            if (checkBox1.Checked)
            {
                int i = 0;
                do
                {
                    if (radioButton1.Checked)
                    {
                        if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_swapped_1_3_" + i + extension))
                        {
                            fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_swapped_1_3_" + i + extension;
                            break;
                        }
                        else i++;
                    }
                    else if (radioButton2.Checked)
                    {
                        if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_swapped_2_4_" + i + extension))
                        {
                            fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_swapped_2_4_" + i + extension;
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
                    if (!File.Exists(Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_" + i + extension))
                    {
                        fileName = Path.GetFileNameWithoutExtension(textBox1.Text) + reversedName + "_" + i + extension;
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
                        if (saveFileDialog1.FilterIndex == 1) File.WriteAllBytes(saveFileDialog1.FileName, write);
                        else if(saveFileDialog1.FilterIndex == 2)
                        {
                            if(Convert.ToInt32(freq) != 44100 && Convert.ToInt32(freq)!= 48000)
                            {
                                MessageBox.Show("Saving into MP3 possible only with 44100 and 48000 Hz! Save it into WAV and convert it with another programm!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if(bitDepth != 16)
                            {
                                MessageBox.Show("Saving into MP3 possible only with 16 bits! Save it into WAV and convert it with another programm!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if(channels > 2)
                            {
                                MessageBox.Show("Saving into MP3 possible only with 1 and 2 channels! Save it into WAV and convert it with another programm!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bitrate bit = new bitrate();
                            bit.ShowDialog();
                            if (bit.DialogResult == DialogResult.Cancel) return;
                            NAudio.MediaFoundation.MediaFoundationInterop.MFStartup(0);
                            WaveFormat wav = new WaveFormat(Convert.ToInt32(freq), channels);
                            using (var writer = new NAudio.Wave.RawSourceWaveStream(write, 44 + dataStartOffset, dataSize, wav))
                            {
                                NAudio.Wave.MediaFoundationEncoder.EncodeToMp3(writer, saveFileDialog1.FileName, mp3Bitrate);
                            }
                        }
                        break;
                    }
                    catch
                    {
                        MessageBox.Show("File is busy, or there's an error! Try again or choose another name!\nIf you saving to MP3 and using Windows 7, choose WAV!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            reworkFile();
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
            reworkFile();
            float checkBPM;
            if(float.TryParse(textBox3.Text, out checkBPM) == false)
            {
                MessageBox.Show("Invalid BPM! Try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (float.TryParse(offsetText.Text, out checkBPM) == false)
            {
                MessageBox.Show("Invalid offset! Try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            textBox3.Enabled = false;
            swapButton.Enabled = false;
            checkBox1.Enabled = false;
            saveButton.Enabled = false;
            openButton.Enabled = false;
            offsetText.Enabled = false;
            previewButton.Enabled = false;
            reverse.Enabled = false;
            swappedFile = null;
            //try
            //{
                ref byte[] workingBytes = ref originalFile;
                if (reverse.Checked) workingBytes = ref reversedFile;
                float bpm = Convert.ToSingle(textBox3.Text);
                swappedFile = new byte[workingBytes.Length];
                float bps = bpm / 60;
                int swapBytes = Convert.ToInt32((1 / bps) * bytesPerSecond);
                while (true)
                {
                    if (swapBytes % (bitDepth * channels / 8) != 0) swapBytes--;
                    else break;
                }
                int offset = Convert.ToInt32(Convert.ToSingle(offsetText.Text) * bytesPerSecond);
                int blocks = (dataSize / swapBytes) - 4;
                for (int i = 0; i < 44 + dataStartOffset; i++)
                {
                    swappedFile[i] = workingBytes[i];
                }
                for (int i = 44 + dataStartOffset; i < offset  + 44 + dataStartOffset; i++)
                {
                    swappedFile[i] = workingBytes[i];
                }
                for (int i = 0; i < blocks - (offset / swapBytes); i += 4)
                {
                    if (radioButton1.Checked)
                    {
                        for (int r = 44 + dataStartOffset + offset + (i * swapBytes); r < 44 + dataStartOffset + offset + swapBytes + (i * swapBytes); r++)
                        {
                            swappedFile[r] = workingBytes[r + swapBytes + swapBytes];
                            swappedFile[r + swapBytes + swapBytes] = workingBytes[r];
                            swappedFile[r + swapBytes] = workingBytes[r + swapBytes];
                            swappedFile[r + swapBytes + swapBytes + swapBytes] = workingBytes[r + swapBytes + swapBytes + swapBytes];
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        for (int r = 44 + dataStartOffset + offset + (i * swapBytes); r < 44 + dataStartOffset + offset + swapBytes + (i * swapBytes); r++)
                        {
                            swappedFile[r + swapBytes] = workingBytes[r + swapBytes + swapBytes + swapBytes];
                            swappedFile[r + swapBytes + swapBytes + swapBytes] = workingBytes[r + swapBytes];
                            swappedFile[r] = workingBytes[r];
                            swappedFile[r + swapBytes + swapBytes] = workingBytes[r + swapBytes + swapBytes];
                        }
                    }
                }
                for (int i = 44 + dataStartOffset + offset + (blocks * swapBytes) - ((offset / swapBytes) * swapBytes); i < workingBytes.Length; i++)
                {
                    swappedFile[i] = workingBytes[i];
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Something wrong with WAV file or BPM/offset! Try to convert it again or download it from another source or change BPM/offset!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            textBox3.Enabled = true;
            swapButton.Enabled = true;
            checkBox1.Enabled = true;
            offsetText.Enabled = true;
            saveButton.Enabled = true;
            openButton.Enabled = true;
            previewButton.Enabled = true;
            saveButton.Enabled = true;
            reverse.Enabled = true;
            //radioButton1.Enabled = true;
            //radioButton2.Enabled = true;            
        }

        private void offsetText_TextChanged(object sender, EventArgs e)
        {
            //if (offsetText.Text == "") offsetText.Text = "0";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "") swapButton.Enabled = true;
        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BeatSwapper\nWritten by Denis \"DB\" Boyarchuk\nt.me/russkiypoopforever\ngithub.com/DBmain/BeatSwapper\n\nNAudio library by naudio\nhttps://github.com/naudio/naudio", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BeatSwapper_Load(object sender, EventArgs e)
        {

        }

        private void Reverse_CheckedChanged(object sender, EventArgs e)
        {
            bool radioEnabled = false;
            if (checkBox1.Checked) radioEnabled = true;
            checkBox1.Enabled = false;
            saveButton.Enabled = false;
            openButton.Enabled = false;
            previewButton.Enabled = false;
            reversedFile = new byte[originalFile.Length];
            if (radioEnabled)
            {
                swapButton.Enabled = false;
                radioButton1.Enabled = false; 
                radioButton2.Enabled = false;
                textBox3.Enabled = false;
                offsetText.Enabled = false;
            }
            if (reverse.Checked)
            {
                for (int i = 0; i < 44 + dataStartOffset; i++)
                {
                    reversedFile[i] = originalFile[i];
                }
                for(int i = 44 + dataStartOffset; i < 44 + dataStartOffset + dataSize; i++)
                {
                    reversedFile[i] = originalFile[44 + dataStartOffset + dataSize - i];
                }
            }
            checkBox1.Enabled = true;
            saveButton.Enabled = true;
            openButton.Enabled = true;
            previewButton.Enabled = true;
            if (radioEnabled)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                swapButton.Enabled = true;
                textBox3.Enabled = true;
                offsetText.Enabled = true;
            }
            swappedFile = null;
            if (checkBox1.Checked) saveButton.Enabled = false;
        }
    }
}





//    old code
        /* static string LEtoDecByte(byte[] littleEndian)
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
        } */
