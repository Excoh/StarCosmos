using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starnamegenerator : MonoBehaviour {

	public string[] names = {"Orion","Zeus","Jupiter",
		"Aldebaran","Apollo","Mercury","Hermes","Scorpio","Capricorn",
	"Beavis","Olympus","Athena","Hera","Hephaestion","Cosmo","Sagan",
	"Alien","Martian","Skywalker","Starfire","Arnold","Soviet","Titan",
	"Quaid","Total","Ultimate","Sparta","Taurus","Gemini","Libra",
	"Zodiac","Snake","Particulate","Phoenix","Wyvern","Deity","Hades",
	"Poseidon","Neptune","Pluto","Ceres","Corn","Lincoln","Washington",
	"Douglas Quaid","Cygnus","Sirius","Acrux","Altair","Castor","Beatrix",
	"Governator","Terminator","Han Solo","Darth Vader","Darth Maul", "Aphrodite",
	"Polaris","Hamal","Ultimate","Kochab","Mintaka","Canopus","Vega","Arcturus",
	"Betelguese","Deneb","Pollux","Regulus","Sargas","Monarch","King","Pericles",
	"Constellio","Star","Sun","Sol","Alpha Centauri","Borealis","Antarcticus",
	"Ptolemy","Socrates","Plato","Caesar","Galileo","Michaelangelo","Leonardo",
	"Tolkien", "Venus", "Hera", "Elon", "Elon Musk", "Armstrong"};

	public string[] prefix = {"Bright", "Great","Uncertain","Cosmic", "Big", "Mighty", "Unfortunately Small",
	"Incredible", "Credible", "Average", "Medium", "Extra Large", "Effervescent", "Reactive", "Incorruptible", "Boreal",
	"Light","Really, Extremely Blue", "Basically Alien", "Extraterrestrial", "Australian", "Sour","Fiery","Brimstoney",
	"Apparent", "Highly Apparent", "Really, Really Apparent", "Ridiculous", "Glorious", "Magnanimous", "Pathetic", "Astronomical",
	"Scientific", "Lord", "Darth", "Non-Galactic", "Certain", "Definite", "Middling", "Prefixed", "Unsudden", "Sudden", "Surprising",
	"Unsurprising", "Rather Inevitable", "Big Inevitable", "Evitable", "Unusual", "Peculiar", "Rather Unusual", "Wide", "Narrow",
	"Star? More Like Planet", "Little", "Microscopic", "Telescopic"};

	public string[] designation = {"Alpha", "Gamma", "Beta", "Psi", "Phi", "Omicron","Delta","Epsilon",
		"Sigma","Mu","Pi","Tau", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Nu", "Rho", "Upsilon", 
		"Chi","Xi", "Prime","I", "II", "Tertiari", "Major", "Minor"};

	public string[] suffix = {"Dipper", "Wolf", "Belt", "Way", "Star", "Crescent", "System", "Terminator",
	"Radiator","Brightener","Stellarius","Entity","Crystal","Diamond","Emerald","Blue-ish Giant", "Redd-ish Dwarf",
	"Redd-ish Giant", "Supergiant", "Hypergiant", "Starsystem", "Solar Body", "Great Mystical Ostrich", "Light",
	"Lamp","Candle","Lantern","Firefly","Great Rift","Abyss","Galaxy","Group","Sector","Constellator","Ecliptor",
	"Alien Mothership","Base","Nebula","Eye","Mega-Entity","Supergroup","Minigroup","Constellation","Enclosure",
	"Million Dollar Loan", "Stimulus Plan", "Great Wall of China", "Doomstar", "Mordor", "Lord of the Rings", "Symbols",
	"Equinoxian","Paradox Orb", "Subgalactic Empire", "Interstellar Spacecraftian", "Magnitudius Maximus","Spheres", "Mighty Fireball", 
	"Mega Fireballs", "Big Stars", "Mighty Britches", "Pawn Shop", "Plasma"};

	string generateName()
	{

		string result = "Star";

		int nameNum = Random.Range (0, names.Length);
		int prefixNum = Random.Range (0, prefix.Length);
		int greekNum = Random.Range (0, designation.Length);
		int suffixNum = Random.Range (0, suffix.Length);

		int factor = Random.Range (1, 7);

		if (factor == 1 || factor == 5) 
		{
			result = names[nameNum] + "'s " + prefix[prefixNum];

		} 
		else if (factor == 2) 
		{
			result = names[nameNum] + " " + designation[greekNum];

		} 
		else if (factor == 3 || factor == 4) 
		{
			result = prefix [prefixNum] + " " + suffix[suffixNum];

		} 
		else if (factor == 6) 
		{
			result = designation[greekNum] + " " + names[nameNum];
		} 
		else if (factor == 7) 
		{
			result = prefix [prefixNum] + " " + names [nameNum];

		}

		return result;

	}

	// Use this for initialization
	void Start () {
		string toPrint = generateName ();
		print (toPrint);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			print( generateName ());
		}
	}
}
