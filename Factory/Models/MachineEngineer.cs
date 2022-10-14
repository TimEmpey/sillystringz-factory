namespace Factory.Models
{
  public class MachineEngineer
  {       
    public int MachineEngineerId { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public virtual Engineer Engineer { get; set; }
    public virtual Machine Machine { get; set; }
  }
}