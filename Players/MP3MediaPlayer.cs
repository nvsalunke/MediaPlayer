using System;
using System.Linq;

namespace MediaPlayer
{
    internal class MP3MediaPlayer : IMediaPlayer
    {
        public string Decompress(string file)
        {
            /* Code to decompress file */
            Console.WriteLine($"Decompressing MP3 file : {file}");
            return "output file";
        }

        public void Play(string file, IMediaEffect[] mediaEffects)
        {
            /* Code to play mp3 file using mediaEffects*/
            Console.WriteLine($"Playing MP3 file : {file}, with effects:");
            mediaEffects.ToList().ForEach(effect => effect.ApplyEffect());
        }
    }
}