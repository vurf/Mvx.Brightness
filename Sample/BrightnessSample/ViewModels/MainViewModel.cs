using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Brightness;

namespace BrightnessSample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IBrightnessService brightnessService;
        private string _text = "Hello MvvmCross";
        private float tempBrightness;

        public MainViewModel(IBrightnessService brightnessService)
        {
            this.brightnessService = brightnessService;
        }

        public IMvxCommand MakeBrightCommand => new MvxCommand(this.SetBrightness);

        public IMvxCommand ReturnBrightCommand => new MvxCommand(this.ReturnBrightness);
        
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);

        public override Task Initialize()
        {
            this.tempBrightness = this.brightnessService.GetBrightness();
            return base.Initialize();
        }

        private void SetBrightness()
        {
            this.brightnessService.SetBrightness(1);
        }

        private void ReturnBrightness()
        {
            this.brightnessService.SetBrightness(this.tempBrightness);
        }

        private void ResetText()
        {
            Text = "Hello MvvmCross";
        }

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}