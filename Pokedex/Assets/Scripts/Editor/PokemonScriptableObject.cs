using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName ="new_pokemon", menuName = "Pokedex/Create Pokemon")]
public class PokemonScriptableObject : ScriptableObject {
	[HorizontalGroup("Split", 0.5f, LabelWidth = 100)]
	[ReadOnly]
	[BoxGroup("Split/Left")]
	public string pokemonName;
	[ReadOnly]
	[BoxGroup("Split/Left")]
	public int id;
	[PreviewField(100, ObjectFieldAlignment.Right)]
	[BoxGroup("Split/Right")]
	public Sprite sprite;
	
	[HorizontalGroup(("Types"))]
	[ReadOnly] 
	public List<Type> type;
	[HideLabel] public Stat stats;
	[TextArea(5,20)]
	[ReadOnly] public string description;
}