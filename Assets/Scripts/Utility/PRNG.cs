using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRNG
{
    System.Random prng;
	int seed;

	public int Seed {
		get {
			return seed;
		}
	}

	public PRNG (int seed) {
		this.seed = seed;
		prng = new System.Random (this.seed);
	}

	public PRNG (string seed) {
		this.seed = seed.GetHashCode ();
		prng = new System.Random (this.seed);
	}

	public PRNG () {
		prng = new System.Random ();
	}

	/// Returns a random integer value [min, max)
	public int Range (int min, int max) {
		return prng.Next (min, max);
	}

	/// Returns a random float value [min, max)
	public float Range (float min, float max) {
		return Mathf.Lerp (min, max, (float) prng.NextDouble ());
	}

	// Returns a vector4 where each component is a random number in range [min, max)
	public Vector4 RangeVector4 (float minInclusive, float maxExclusive) {
		Vector4 vector = Vector4.zero;
		for (int i = 0; i < 4; i++) {
			vector[i] = Range (minInclusive, maxExclusive);
		}
		return vector;
	}

	/// Random value [0, 1]
	public float Value () {
		// According to stackoverflow this should technically allow the random value to equal 1 
		const double maxExclusive = 1.0000000004656612875245796924106;
		return (float) (prng.NextDouble () * maxExclusive);
	}
    
    /// Random value [-1, 1]
	public float SignedValue () {
		return Value () * 2 - 1;
	}
	
	/// Random bool
	public bool GetBool () {
		return (Value () * 2 - 1) < 0? false:true;
	}
}
