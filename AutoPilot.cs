void Main() 
{ 
    Echo ("Stuff");    
// Get blocks 
    var blocks = new List<IMyTerminalBlock>(); 

    // Get a Block
    GridTerminalSystem.GetBlocksOfType<IMyBatteryBlock>(blocks); 

    if(blocks.Count > 0) 
    { 
        IMyTerminalBlock Block = blocks[0]; 

        // Get time now 
        var Time1 = System.DateTime.Now; 
        long OldTime = 0; 

        // We pull this here to prevent conversions being *too* weird 
        long CurrentTime = Time1.ToBinary(); 

        // Store the current name 
        String CurrentName = Block.CustomName; 

        // Get the fragments (or get one fragment) 
        String[] Fragments = CurrentName.Split('|'); 

        // Get coordinates (VRageMath.Vector3D, so pull it in the ugly way) 
        double x = Math.Round(Block.GetPosition().GetDim(0), 4); 
        double y = Math.Round(Block.GetPosition().GetDim(1), 4); 
        double z = Math.Round(Block.GetPosition().GetDim(2), 4); 
        Echo ("x: " + x.ToString());

        // Allocate this here 
        double X = 0; 
        double Y = 0; 
        double Z = 0; 

        // Start with "the unknown" speed, stored in m/s 
        double Speed = 0.0; 

        // Total distance moved 
        double Distance = 0; 

        // Do we actually have fragments? 
        if(Fragments.Length == 3) 
        { 
            // Yes? Excellent. 
            OldTime = Convert.ToInt64(Fragments[1]); 

            // Vomit a bit here because this is how we have to store variables at the moment ... 
            string[] Coords = Fragments[2].Split(','); 
            X = Math.Round(Convert.ToDouble(Coords[0]), 4); 
            Y = Math.Round(Convert.ToDouble(Coords[1]), 4); 
            Z = Math.Round(Convert.ToDouble(Coords[2]), 4); 

            // Nothing fancy here 
            Distance = System.Math.Sqrt( 
                ((x-X)*(x-X)) + ((y-Y)*(y-Y)) + ((z-Z)*(z-Z)) 
            ); 
        } 

        // If the base coordinates 
        if (Distance != 0 && X != 0 && Y != 0 && Z != 0 && OldTime != 0) 
        { 
            // Update time 
            var Time0 = System.DateTime.FromBinary(OldTime); 

            // We have 's' for m/s. 
            var TimeDelta  = (Time1 - Time0).TotalSeconds; 

            // We have our distance 
            Speed = Distance / TimeDelta; 
        } 

        // Speed|Time|X,Y,Z 
        String NewName = Speed.ToString() + "|" + 
            CurrentTime.ToString() + "|" + 
            x.ToString() + "," + y.ToString() + "," + z.ToString();
        Echo (NewName);
       // Store it 
        Block.SetCustomName(NewName); 

        
        
    } 
}