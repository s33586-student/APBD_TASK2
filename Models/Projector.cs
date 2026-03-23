namespace APBD_TASK2.Models;

public class Projector: Equipment
{
    public string Resolution { get; set; }
    public int Brightness { get; set; }

    public Projector(string name, string resolution, int brightness) : base(name)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
}