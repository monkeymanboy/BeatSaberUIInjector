using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;

namespace BeatSaberUIInjector
{
    class GlobalHost : NotifiableSingleton<GlobalHost>
    {
        private bool wonLastLevel;
        [UIValue("won-last-level")]
        public bool WonLastLevel
        {
            get => wonLastLevel;
            set
            {
                wonLastLevel = value;
                NotifyPropertyChanged();
            }
        }
        private bool lostLastLevel;
        [UIValue("lost-last-level")]
        public bool LostLastLevel
        {
            get => lostLastLevel;
            set
            {
                lostLastLevel = value;
                NotifyPropertyChanged();
            }
        }
    }
}
