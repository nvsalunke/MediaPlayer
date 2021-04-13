using System;

namespace MediaPlayer
{
    class MediaPlayerFactory
    {
        public IMediaPlayer GetMediaPlayer(MediaFormat format, IMediaPlugIn mediaPlugIn=null) {
            switch (format) {
                case MediaFormat.MP3: return new MP3MediaPlayer();
                case MediaFormat.FLAC: return new FLACMediaPlayer();
                case MediaFormat.Custom: return mediaPlugIn.GetPlayer();
                default: throw new Exception("Format not supported by default and no plug-in provided");
            }
        }
    }
}
