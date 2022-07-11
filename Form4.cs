using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Diagnostics;

namespace Voice_Calculator
{
    public partial class OutputPage : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        public OutputPage()
        {
            InitializeComponent();
        }

        private void OutputPage_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 149, 237);
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            Startbtn.Enabled = false;
            Stopbtn.Enabled = true;

            Grammar voiceActionsGrammar = new Grammar(@"c:\Users\hp\Documents\VoiceActions.xml");
            voiceActionsGrammar.Name = "SRGS File Voice Actions Grammar";

            try
            {
                sre.RequestRecognizerUpdate();
                sre.SpeechRecognized += sre_SpeechRecognized;
                sre.LoadGrammar(voiceActionsGrammar);
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string inputVoice = e.Result.Text.ToString();
            OutputBox.Text += e.Result.Text.ToString() + Environment.NewLine;
        }

        private void Stopbtn_Click(object sender, EventArgs e)
        {
            sre.RecognizeAsyncStop();
            Startbtn.Enabled = true;
            Stopbtn.Enabled = false;
        }
    }
}
