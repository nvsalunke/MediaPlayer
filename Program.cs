namespace MediaPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            MediaProcessor mediaProcessor = new MediaProcessor();
            mediaProcessor.Process(args);
        }
    }
}
