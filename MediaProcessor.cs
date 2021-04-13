using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MediaPlayer
{
    class MediaProcessor
    {
        public void Process(string[] args)
        {

            /* code that parses the arguments */

            if (args.Length < 2)
            {
                throw new Exception("Not enough parameters provided");
            }

            string operation = args[0];
            string file = args[1];
            string extension = Path.GetExtension(file);
            extension = extension.Substring(1, extension.Length - 1);


            bool isSupportedFormat = Enum.TryParse(extension, ignoreCase: true, out MediaFormat format);

            IMediaPlugIn mediaPlugIn = null;
            int effectStartIndex = 2;
            if (!isSupportedFormat)
            {
                if (args.Length < 4)
                {
                    throw new Exception("Custom media type requires plugin asembly path and it's type");
                }
                format = MediaFormat.Custom;
                mediaPlugIn = GetMediaPlugIn(args[2], args[3]);
                effectStartIndex = 4;
            }
            string[] effects = args.Skip(effectStartIndex).ToArray(); //new string[args.Length - effectStartIndex+1];
            //args.CopyTo(effects, effectStartIndex);

            IMediaEffect[] mediaEffects = GetMediaEffects(effects);

            MediaPlayerFactory factory = new MediaPlayerFactory();
            IMediaPlayer player = factory.GetMediaPlayer(format, mediaPlugIn);
            Enum.TryParse(operation, out MediaOperation mediaOperation);
            switch (mediaOperation)
            {
                case MediaOperation.Play:
                    player.Play(file, mediaEffects);
                    break;
                case MediaOperation.Decompress:
                    player.Decompress(file);
                    break;
                default: throw new InvalidOperationException("Operation not supported");
            }

        }

        private IMediaEffect[] GetMediaEffects(string[] effects)
        {
            /* Code to return convert string effect into MediaEffect instaces. We can again use factory pattern here*/
            MediaEffectFactory mediaEffectFactory = new MediaEffectFactory();

            var mediaEffects = effects.ToList().Select(effect =>
            {
                Enum.TryParse(effect, ignoreCase: true, out MediaEffect mediaEffect);
                return mediaEffectFactory.GetEffect(mediaEffect);
            });
            return mediaEffects.ToArray();
        }

        private IMediaPlugIn GetMediaPlugIn(string plugInPath, string type)
        {
            Assembly assembly = Assembly.Load(plugInPath);
            Type plugInType = assembly.GetType(type);
            return (IMediaPlugIn)Activator.CreateInstance(plugInType);
        }
    }
}
