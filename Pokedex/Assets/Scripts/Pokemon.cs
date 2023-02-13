using UnityEngine;
using Sirenix.OdinInspector;

public enum Type {
	Normal,
	Fire,
	Fighting,
	Water,
	Poison,
	Electric,
	Ground,
	Grass,
	Flying,
	Ice,
	Bug,
	Psychic,
	Rock,
	Dragon,
	Ghost,
	Dark,
	Steel,
	Fairy
}

[System.Serializable]
public struct Stat {
	[HorizontalGroup("1")]
	public int HP;
	[HorizontalGroup("1")]
	public int ATK;
	[HorizontalGroup("2")]
	public int DEF;
	[HorizontalGroup("2")]
	public int SPD;
	[HorizontalGroup("3")]
	public int SAT;
	[HorizontalGroup("3")]
	public int SDF;
}

public class Pokemon : MonoBehaviour {
	public string name;
	public Sprite sprite;
	public Type[] type;
	public Stat stats;
	public float height;
	public float weight;
	public string description;
}
