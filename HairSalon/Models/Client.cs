namespace HairSalon.Models
{
  public class Client
  {
    //These are just properties
    public int ClientId { get; set; }
    public int StylistId { get; set; }
    public string Name { get; set; }
    public virtual Stylist Stylist {get; set;}
  }
}