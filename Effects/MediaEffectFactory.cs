using System;

namespace MediaPlayer
{
    internal class MediaEffectFactory
    {
        public MediaEffectFactory()
        {
        }

        public IMediaEffect GetEffect(MediaEffect effect)
        {
            switch (effect)
            {
                case MediaEffect.ExtraBass: return new ExtraBassEffect();
                case MediaEffect.ExtraTreble: return new ExtraTrebleEffect();
                default: throw new Exception("Effect not supported by default and no plug-in provided");
            }
        }
    }
}