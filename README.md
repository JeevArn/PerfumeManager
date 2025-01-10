# PerfumeManager
Projet POO 2024 - création d'un exécutable en ligne de commande en C#

## Présentation
Ce programme permet de faire des requêtes sur une base de données de parfums. Les données sont stockées dans un fichier csv. Il contient les champs ID, Name, Brand, Notes, ScentProfile. Les données ont été obtenu à partir du site fragrantica.com. Afin de miniser le temps d'exécution du code, nous utilisons uniquement une petite partie de la base de donnée (49 parfums).

## Usage

### Lancement du programme
```sh
dotnet build
dotnet run
```
### Charger le dataset en CSV
```
load <csvfilepath>
```
Exemple:
```
load Data/perfumes.csv
```
### Ajouter un parfum
```
add <id> <name> <brand> <note> <scentprofile>
```
Exemple :
```
add 50 Terracotta Guerlain vanilla,ylang-ylang Floral
```
Attention ! 
- Les notes doivent êtres séparées par des virgules, sans espaces
- Pour les noms composés, il faut mettre des _ à la place des espaces
Exemple :
```
add 51 Manifesto Yves_Saint_Laurent vanilla,tonka_bean Wood
```
- la case est ignorée pour tous les arguments

### Enregistrer la base de donnée en CSV
```
save <csvfilepath>
```
Exemple :
```
save Data/updated_perfumes.csv
```

### Rechercher des parfums
#### Par nom
```
search <perfumeName>
```
Exemple :
```
search name No._5
```
#### Par marque
```
search <perfumeBrand>
```
Exemple :
```
search brand Chanel
```
#### Par note
```
search <Note>
```
Exemple :
```
search note Vanilla
```
#### Par scentProfile
```
search <Floral|Fresh|Amber|Wood>
```
Exemple :
```
search scentprofile Floral
```

### Sérialiser la base de données en JSON
```
write_json <jsonfilepath>
```
Exemple :
```
write_json Data/updated_perfumes.json
```
### Désérialiser un fichier JSON
```
read_json <jsonfilepath>
```
Exemple :
```
read_json Data/updated_perfumes.json
```

### Ecrire l'historique des commandes dans un fichier TXT
```
write_history <txtfilepath>
```
Exemple :
```
write_history history.txt
```
Effectuer au préalable des commandes afin de ne pas avoir un historique vide.

### Afficher l'aide
```
help
```

### Quitter le programme
```
exit
```
