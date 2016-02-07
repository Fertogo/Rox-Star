using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
using UnityEngine.UI;



public class LyricAnimator : MonoBehaviour {
	
	public class LRCLine : MonoBehaviour {

		public float TStart;

		public string Lyric;
	}


	TextMesh lyrics;
	TextMesh prevLyrics;
	TextMesh nextLyrics;
	AudioSource sound;
	List<LRCLine> lrc;
	int currentLrc = 0;


	// Use this for initialization
	void Start () {
		lyrics = GetComponent<UnityEngine.TextMesh>();
		sound = GetComponent<AudioSource>();


		string lyricsStr = loadFileAsString ("Assets/Music/journey.lrc");

		lrc = ParseLRC (lyricsStr);
		lyrics.text = lrc [0].Lyric;

		prevLyrics = (TextMesh) GameObject.Find("prevLine").GetComponent<UnityEngine.TextMesh>();
		prevLyrics.text = "";
		nextLyrics = (TextMesh) GameObject.Find("nextLine").GetComponent<UnityEngine.TextMesh>();
		nextLyrics.text = lrc [1].Lyric;


		sound.Play ();
		sound.Play(44100);

	}

	List<LRCLine> ParseLRC(String input) {

		string[] lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
		List<LRCLine> output = new List<LRCLine> ();
		for (int i = 0; i < lines.Length; i++) {
			string line = lines [i];

			if (System.Text.RegularExpressions.Regex.IsMatch (line, "^\\[[0-9].*")) {
				LRCLine lrc = new LRCLine ();
				lrc.Lyric = line.Substring(line.IndexOf("]")+1);
				String timing = line.Substring (1, line.IndexOf ("]") - 1);
				float time = (float) TimeSpan.Parse("00:" + timing).TotalSeconds;
				lrc.TStart = time;
				output.Add (lrc);
			}
		}

		return output;
	}

	// Update is called once per frame
	void Update () {


		float time = Time.fixedTime;

		if (currentLrc+1 < lrc.Count) {
			if (time > lrc [currentLrc+1].TStart) {

				lyrics.text = lrc [currentLrc + 1].Lyric;
				prevLyrics.text = lrc [currentLrc].Lyric;
				if (currentLrc+2 < lrc.Count) {
					nextLyrics.text = lrc [currentLrc + 2].Lyric;
				}
				currentLrc++;
			}
				
		}

		/*lyrics.text = "hello";
		switch (time) {
		case 10:
			sound.Stop ();
			break;
		}*/
	
	}

	private string loadFileAsString(string fileName)
	{
		string rtn = "";
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();

					if (line != null)
					{
						rtn += line + "\n";
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return rtn;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			return "";
		}

		return rtn;
	}
}
