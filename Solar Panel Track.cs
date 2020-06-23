 void Main() 
{

            var rotor = GridTerminalSystem.GetBlockWithName("Rotor 2") as IMyMotorStator;
            IMyTextSurface surface = GridTerminalSystem.GetBlockWithName("LCD Panel") as IMyTextSurface;
            IMyBatteryBlock battery = GridTerminalSystem.GetBlockWithName("Battery") as IMyBatteryBlock;
            float pwrNow;
            float pwrLast;
            double rotorAngle = (rotor.Angle * 180) / 3.14; //1rad × 180/π = 57.296°

            if (Storage == null)
            {
                Echo("Storage Empty");
                pwrLast = 0;
            }
            else
            {
                pwrLast = float.Parse(Storage);
            }




            float currentInput = (battery.CurrentInput) * 1000;
            Math.Round(currentInput, 2);
            pwrNow = battery.CurrentInput;
            pwrNow = currentInput;
            if (pwrNow == 0)
            {
                if ((rotorAngle < 270 && rotorAngle > 0) && (rotorAngle > 280 && rotorAngle < 360))
                {
                    rotor.TargetVelocityRPM = 0;
                }
                else
                {
                    rotor.TargetVelocityRPM = 1;

                }
                
            }
            else if (pwrNow > pwrLast || pwrNow >= 250)
            {

                rotor.SetValueFloat("Velocity", 0);
                rotor.TargetVelocityRPM = 0;
                Storage = pwrNow.ToString();

            }
            else if (pwrNow < pwrLast)
            {
                //rotor.ApplyAction("Reverse");
                if (rotor.TargetVelocityRPM == 0)
                {
                    rotor.SetValueFloat("Velocity", .25F);
                }

            }

            surface.WriteText("Rotor Angle: " + rotorAngle + "\nPower Input: " + currentInput.ToString() + "\nPwrLast: " + pwrLast.ToString()
            + "kW\npwrNow: " + pwrNow.ToString() + "kW\n");






        }