namespace MediaPlayer
{
    internal interface IMediaPlayer
    {
        void Play(string file, IMediaEffect[] mediaEffects);
        string Decompress(string file);
    }
}