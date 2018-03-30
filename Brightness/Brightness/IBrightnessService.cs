namespace Brightness
{
    public interface IBrightnessService
    {
        void SetBrightness(float brightness);

        float GetBrightness();
    }
}