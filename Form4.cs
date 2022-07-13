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
using System.IO;
using System.Speech.Recognition.SrgsGrammar;
using System.Globalization;

namespace Voice_Calculator
{
    public partial class OutputPage : Form
    {
        SpeechSynthesizer ss = new SpeechSynthesizer();
        PromptBuilder pb = new PromptBuilder();
        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
      

        // set up the recognizer
        //_speechRecognizer = new SpeechRecognizer();
        //_speechRecognizer.Enabled = false;
        //_speechRecognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_speechRecognizer_SpeechRecognized);

        // set up the command and control grammar
        //Grammar commandGrammar = new Grammar(@"grammar.xml");
        //commandGrammar.Name = "main command grammar";
        //commandGrammar.Enabled = true;

        // activate the command grammer
        //_speechRecognizer.LoadGrammar(commandGrammar);

        //_speechRecognizer.Enabled = true;
        public OutputPage()
        {
            InitializeComponent();
        }

        private void OutputPage_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 149, 237);
        }

       /* private static Grammar CreateGrammarFromFile()
        {
            Grammar citiesGrammar = new Grammar(@"MathCommands.xml");
            citiesGrammar.Name = "SRGS File Cities Grammar";
            return citiesGrammar;
        }
       */
        private void Startbtn_Click(object sender, EventArgs e)
        {
            Startbtn.Enabled = false;
            Stopbtn.Enabled = true;

            Choices clist = new Choices(new string[] { "hi", "what's up", "what time is it", "chrome app", "thanks", "cancel" });

            clist.Add(new string[] { "1 plus 4", "4 minus 2", "what is the current time", "open chrome", "thank you", "close" });
            Grammar gr = new Grammar(new GrammarBuilder(clist));

            SrgsDocument srgsdoc = new SrgsDocument(@"c:\Users\hp\Documents\minusCommands.xml");
            //SrgsDocument srgsdoc_add = new SrgsDocument(@"MathCommands.xml");
            //SrgsDocument srgsdoc = new SrgsDocument(@"c:\Users\hp\Documents\multiplyCommands.xml");
            Grammar grammar = new Grammar(srgsdoc);
            


            //Grammar  = new Grammar();
            /*Grammar voiceActionsGrammar = new Grammar(new GrammarBuilder(@"c:\Users\hp\Documents\VoiceActions.xml"));
            voiceActionsGrammar.Name = "SRGS File Voice Actions Grammar";*/

            try
            {

                sre.RequestRecognizerUpdate();
                sre.SpeechRecognized += sre_SpeechRecognized;
                //sre.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(@"MathCommands.xml"))));
                //voiceActionsGrammar.Enabled = true;
                sre.LoadGrammar(grammar);
                sre.SetInputToDefaultAudioDevice();
                //sre.SpeechDetected += sre_SpeechDetected;
                //sre.SpeechHypothesized += sre_SpeechHypothesized;
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void Sre_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string inputVoice = e.Result.Text.ToString();
            // Taking a string

            string[] separator = {" "};

            // using the method
            string[] strlist = inputVoice.Split(separator,
               StringSplitOptions.RemoveEmptyEntries);

            int firstOperand;
            int secondOperand;

            bool firstParsable = int.TryParse(strlist[0], out firstOperand);
            bool secondParsable = int.TryParse(strlist[2], out secondOperand);

            if(firstParsable && secondParsable)
            {
                switch (strlist[1])
                {
                    case "plus":
                        int sum = firstOperand + secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + sum);
                        break;
                    case "minus":
                        int subtract = firstOperand - secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + subtract);
                        break;
                    case "divides":
                        int divide = firstOperand / secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + divide);
                        break;
                    case "times":
                        int multiply = firstOperand * secondOperand;
                        ss.SpeakAsync(inputVoice + "=" + multiply);
                        break;
                }
            }
            

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
