namespace shuffle.models
{
    public class Player
    {
        public Player(Attendee attendee, Role role)
        {
            Attendee = attendee;
            Role = role;
        }
        public Attendee Attendee { get; set; }
        public Role Role { get; set; }

        public override string ToString()
        {
            return $"{Attendee}, role: {Role}";
        }
    }
}