int inRange;
public Program()
{
    // The constructor, called only once every session and
    // always before any other method is called. Use it to
    // initialize your script. 
    //     
    // The constructor is optional and can be removed if not
    // needed.
    // 
    // It's recommended to set RuntimeInfo.UpdateFrequency 
    // here, which will allow your script to run itself without a 
    // timer block.
}

public void Save()
{
    // Called when the program needs to save its state. Use
    // this method to save your state to the Storage field
    // or some other means. 
    // 
    // This method is optional and can be removed if not
    // needed.
}

public void Main()
{

var rotor = GridTerminalSystem.GetBlockWithName("Prog Advanced Rotor") as IMyMotorStator;
			
			var piston1 = GridTerminalSystem.GetBlockWithName("Piston 1") as IMyPistonBase;
			var piston2 = GridTerminalSystem.GetBlockWithName("Piston 2") as IMyPistonBase;
			var piston3 = GridTerminalSystem.GetBlockWithName("Piston 3") as IMyPistonBase;
			var piston4 = GridTerminalSystem.GetBlockWithName("Piston 4") as IMyPistonBase;
			var piston5 = GridTerminalSystem.GetBlockWithName("Piston 5") as IMyPistonBase;
			var piston6 = GridTerminalSystem.GetBlockWithName("Piston 6") as IMyPistonBase;

double rotorAngle = Math.Round(rotor.Angle * 180 / 3.14, 2); //1rad × 180/pi = 57.296°


if (Storage == null) {
    inRange = 0;
    Echo ("Storage is null");
} 
else {
inRange = int.Parse(Storage);
}

         
Echo ("Rotor Angle: " + rotorAngle.ToString());
Echo ("Piston 1 Max: " + piston1.MaxLimit.ToString());
Echo ("Piston 2 Max: " + piston2.MaxLimit.ToString());
Echo ("Piston 3 Max: " + piston3.MaxLimit.ToString());
Echo ("Piston 4 Max: " + piston4.MaxLimit.ToString());
Echo ("Piston 5 Max: " + piston5.MaxLimit.ToString());
Echo ("Piston 6 Max: " + piston6.MaxLimit.ToString());


float piston1MaxValue = piston1.MaxLimit;
float piston2MaxValue = piston2.MaxLimit;
float piston3MaxValue = piston3.MaxLimit;
float piston4MaxValue = piston4.MaxLimit;
float piston5MaxValue = piston5.MaxLimit;
float piston6MaxValue = piston6.MaxLimit;
//|| (rotorAngle >= 179.98 && rotorAngle <= 180.02)
	if (((rotorAngle >= 89.98 && rotorAngle <= 90.02) ) && inRange == 0)
    {
		inRange = 1;
    
     
    
        if (piston1.MaxLimit < 10.0)
        {
          
            piston1MaxValue += 1;
            if (piston1MaxValue > 10.0) {
             piston1MaxValue = 10.0f;
            }   
            piston1.SetValue("UpperLimit", piston1MaxValue);
            Echo ("More to go");
    
           }
		else if (piston2.MaxLimit < 10.0)
        {
          
            piston2MaxValue += 1;
            if (piston2MaxValue > 10.0) {
             piston2MaxValue = 10.0f;
            }   
            piston2.SetValue("UpperLimit", piston2MaxValue);
            Echo ("More to go");
    
           }
		else if (piston3.MaxLimit < 10.0)
        {
          
            piston3MaxValue += 1;
            if (piston3MaxValue > 10.0) {
             piston3MaxValue = 10.0f;
            }   
            piston3.SetValue("UpperLimit", piston3MaxValue);
            Echo ("More to go");
    
           }
		else if (piston4.MaxLimit < 10.0)
        {
          
            piston4MaxValue += 1;
            if (piston4MaxValue > 10.0) {
             piston4MaxValue = 10.0f;
            }   
            piston4.SetValue("UpperLimit", piston4MaxValue);
            Echo ("More to go");
    
           }
		else if (piston5.MaxLimit < 10.0)
        {
          
            piston5MaxValue += 1;
            if (piston5MaxValue > 10.0) {
             piston5MaxValue = 10.0f;
            }   
            piston5.SetValue("UpperLimit", piston5MaxValue);
            Echo ("More to go");
    
           }
		else if (piston6.MaxLimit < 10.0)
        {
          
            piston6MaxValue += 1;
            if (piston6MaxValue > 10.0) {
             piston6MaxValue = 10.0f;
            }   
            piston6.SetValue("UpperLimit", piston6MaxValue);
            Echo ("More to go");
    
           }
		
	}
	else {
	inRange = 0;
	}
	Storage = inRange.ToString();
}
