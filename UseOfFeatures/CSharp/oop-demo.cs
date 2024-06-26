using System;

// Interface for body parts with color
interface IColorable
{
    string Color { get; }
}

// Class representing a human body part
class BodyPart
{
    // Common properties and methods for all body parts
}

// Class representing a head
class Head : BodyPart
{
    public Eye Eye { get; set; }
    public Mouth Mouth { get; set; }
    public Nose Nose { get; set; }
    public Ear Ear { get; set; }

    public string GetEyeColor()
    {
        return Eye.Color;
    }
}

// Class representing an eye
class Eye : BodyPart, IColorable
{
    public string Color { get; }

    public Eye(string color)
    {
        Color = color;
    }
}

// Class representing a mouth
class Mouth : BodyPart
{
    // Properties and methods specific to mouth
}

// Class representing a nose
class Nose : BodyPart
{
    // Properties and methods specific to nose
}

// Class representing an ear
class Ear : BodyPart
{
    // Properties and methods specific to ear
}

// Class representing a person's body regions
class BodyRegions
{
    public Head Kafa { get; }

    public BodyRegions()
    {
        Kafa = new Head
        {
            Eye = new Eye("Brown"),
            Mouth = new Mouth(),
            Nose = new Nose(),
            Ear = new Ear()
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        BodyRegions regions = new BodyRegions();

        // Accessing all body parts under Kafa
        Console.WriteLine("Göz rengi: " + regions.Kafa.GetEyeColor());

        // Accessing Eye color directly
        Console.WriteLine("Göz rengi: " + regions.Kafa.Eye.Color);
    }
}