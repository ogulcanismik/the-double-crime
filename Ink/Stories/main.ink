EXTERNAL DiscoverNPC()
EXTERNAL ModifyOpinion(int amount)

INCLUDE AdaS1.ink
INCLUDE ArthurS1.ink
INCLUDE BastianS1.ink
INCLUDE ValeriaS1.ink
INCLUDE FionaS1.ink
INCLUDE CS1.ink


VAR speaker = ""

{ speaker:
-"Ada":->ada_basamak_1
-"Arthur":->arthur_basamak_1
-"Bastian":->bastian_basamak_1
-"Valeria":->valeria_basamak_1
-"Fiona":->fiona_basamak_1
-"C":->c_basamak_1
- else: -> fiona_basamak_1
}