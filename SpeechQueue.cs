using System;
using System.Speech.Synthesis;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class SpeechQueue
{
    private Queue<string> speechQueue = new Queue<string>();
    private SpeechSynthesizer synthesizer;
    private bool isSpeaking = false;
	public event Action<string> LogNeeded;

	public SpeechQueue(int speechRate)
    {
        synthesizer = new SpeechSynthesizer();
        synthesizer.Rate = speechRate;
        synthesizer.SpeakCompleted += OnSpeakCompleted;
     
    }

	public void EnqueueSpeech(string text)
	{
		//LogNeeded?.Invoke($"EnqueueSpeech called with text: '{text}' at time: {DateTime.Now}");
		speechQueue.Enqueue(text);
		SpeakNext();
	}


	public void Dequeue()
    {
        speechQueue.Dequeue();
    }

	private void SpeakNext()
	{
		if (!isSpeaking && speechQueue.Count > 0)
		{
			string text = speechQueue.Dequeue();
			//LogNeeded?.Invoke($"EnqueueSpeech called with text: '{text}' at time: {DateTime.Now}");
			isSpeaking = true;
			synthesizer.SpeakAsync(text);
		}
	}


	private void OnSpeakCompleted(object sender, SpeakCompletedEventArgs e)
	{

		//LogNeeded?.Invoke($"EnqueueSpeech called at time: {DateTime.Now}");
		isSpeaking = false;
		SpeakNext();
	}



	public void MuteSpeech()
    {
        synthesizer.Volume = 0;
    }

    public void UnmuteSpeech()
    {
        synthesizer.Volume = 50;
    }
	public void CancelSpeech()
	{
		synthesizer.SpeakAsyncCancelAll();
	}
}
