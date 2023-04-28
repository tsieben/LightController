namespace LightController.Data
{
    public class LightStatus
    {
        public static byte[] data = new byte[512];

        public void setLight(int id, byte red, byte green, byte blue)
        {
            id = id * 3;
            data[id] = red;
            data[id + 1] = green;
            data[id + 2] = blue;
        }

        public LightStatus() { }
    }
}
