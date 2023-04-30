namespace LightController.Data
{
    public class LightStatus
    {
        public static byte[] data = new byte[512];

        /// <summary>
        /// Sets the data to the corresponding channel for lights
        /// </summary>
        /// <param name="id">The numerical id of the lights, needs to be multiplied by 3 to get starting channel</param>
        /// <param name="red">The red channel for the light</param>
        /// <param name="green">The green channel for the light</param>
        /// <param name="blue">The blue channel for the light</param>
        public void setLight(int id, byte red, byte green, byte blue)
        {
            id = id * 3;
            data[id] = red;
            data[id + 1] = green;
            data[id + 2] = blue;
        }

        /// <summary>
        /// Gets the status for the corresponding light
        /// </summary>
        /// <param name="id">The numerical id of the light, needs to be multiplied by 3 to get starting channel</param>
        /// <returns>Returns whether the light is on or off</returns>
        public bool getLight(int id)
        {
            id = id * 3;
            return (data[id] != 0 || data[id + 1] != 0 || data[id + 2] != 0);
        }

        public LightStatus() { }
    }
}
