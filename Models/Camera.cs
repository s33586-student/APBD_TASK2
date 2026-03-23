namespace APBD_TASK2.Models;

public class Camera: Equipment
{
    public int Quality { get; set; }
    public string Lens { get; set; }

    public Camera(string name, int quality, string lens) : base(name)
    {
        Quality = quality;
        Lens = lens;
    }
}