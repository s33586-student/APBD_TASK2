using APBD_TASK2.AbstractModels;

public class Laptop: Equipment
{
    public int RamGb { get; set; }
    public string Model { get; set; }
    
    public Laptop(string name, int ramGb, string model) : base(name)
    {
        RamGb = ramGb;
        Model = model;
    }
}