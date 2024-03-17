using System;
using System.Speech.Synthesis;

namespace Move2VoiceBeta
{
    public class Speech
    {
        private SpeechSynthesizer synthesizer;
        private int speechRate = -3;
		public int volume = 50;

		public Speech(int rate ,int volume)
        {
    
            this.speechRate = rate;  // Store the rate
            synthesizer = new SpeechSynthesizer();
            synthesizer.Rate = this.speechRate;  // Use the stored rate
            synthesizer.Volume = volume;
            synthesizer.SetOutputToDefaultAudioDevice();
        }

        public Action<object, SpeakCompletedEventArgs> SpeakCompleted { get; internal set; }

        public void SpeakAsync(string text)
        {
            try
            {
                synthesizer.SpeakAsync(text);
            }
            catch 
            { 

            }
        }

        public void Mute()
        {
            synthesizer.Volume = 0;
        }

        public void UnMute()
        {
            synthesizer.Volume = 50;
        }
    }
}
