using System;

namespace Quest
{
    public class Hat
    {
        public int shininessLevel { get; set; }
        public string shininessDescription
        { 
            get // Getting description based on value of shininessLevel and returning string descripter
            {
                if (shininessLevel < 2)
                {
                    return "dull";
                }
                else if (shininessLevel >= 2 && shininessLevel <= 5)
                {
                    return "noticeable";
                }
                else if (shininessLevel >= 6 && shininessLevel <= 9)
                {
                    return "bright";
                }
                else 
                {
                    return "blinding";
                }
            }
        }
    }
}