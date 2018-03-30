using System;

namespace Brightness
{
    public abstract class BaseBrightnessService : IBrightnessService
    {
        protected abstract void NativeSet(float brightness);

        public void SetBrightness(float brightness)
        {
            if (brightness < -2 || brightness > 1)
            {
                throw new ArgumentException("The value for percentage must be between 0 and 100");
            }

            this.NativeSet(brightness);
        }

        public abstract float GetBrightness();
    }
}