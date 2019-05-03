using System;
using SkiaSharp;

using GTTG.Core.Strategies.Implementations;
using GTTG.Infrastructure.Model;
using GTTG.Infrastructure.ViewModel;
using GTTG.Model.Lines;
using GTTG.Model.Model.Infrastructure;
using GTTG.Model.Strategies.Types;
using GTTG.Model.ViewModel.Infrastructure.Tracks;

namespace GTTG.Infrastructure.ViewModelFactories { 

    public class TutorialTrackViewFactory : ITrackViewFactory<TutorialTrackView> {

        public static float RedLineStrokeWidth = 3;
        public static float BlueLineStrokeWidth = 1;

        public TutorialTrackView CreateTrackView(Track track) {

            var lineType = LineType.Of(track);
            var segment = new MeasureableSegment<LineType>(lineType);
            return new TutorialTrackView(track, CreateTrackLine(track), segment);
        }

        private static TrackLine CreateTrackLine(Track track) {

            if (!(track is TutorialTrack demoTrack)) {
                throw new ArgumentException("Type of track was not recognized.");
            }

            switch (demoTrack.TrackType) {
                case TrackType.Cargo:
                    return new TrackLine(BlueLineStrokeWidth, SKColors.Blue);
                case TrackType.Passenger:
                    return new TrackLine(RedLineStrokeWidth, SKColors.Red);
                default:
                    throw new ArgumentException($"{nameof(demoTrack.TrackType)} enum member was not recognized.");
            }
        }
    }
}
