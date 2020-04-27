-- (5) insertion dans la table client  
INSERT INTO `cooking`.`client` (`num_C`, `nom_C`, `prenom_C`, `tel_C`, `solde`) VALUES ('JG562', 'Juniot', 'Gérard', 0654324562, 200);
INSERT INTO `cooking`.`client` (`num_C`, `nom_C`, `prenom_C`, `tel_C`, `solde`) VALUES ('BN267', 'Ben souna', 'Nacima', 0656345267, 100);
INSERT INTO `cooking`.`client` (`num_C`, `nom_C`, `prenom_C`, `tel_C`, `solde`) VALUES ('BV354', 'Brique', 'Valentin', 0612827354, 50);
INSERT INTO `cooking`.`client` (`num_C`, `nom_C`, `prenom_C`, `tel_C`, `solde`) VALUES ('RP725', 'Rochelle', 'Pierre', 0645326725, 200);
INSERT INTO `cooking`.`client` (`num_C`, `nom_C`, `prenom_C`, `tel_C`, `solde`) VALUES ('RB467', 'Ricou', 'Blandine', 0698735467, 300);

-- (3) insertion dans la table cdr
INSERT INTO `cooking`.`cdr` (`Pseudo`,`num_C`, `Cdr_Or`, `Cdr_Semaine`,`solde_cook`) VALUES ('Juju','JG562','oui', null,150);
INSERT INTO `cooking`.`cdr` (`Pseudo`, `num_C`,`Cdr_Or`, `Cdr_Semaine`,`solde_cook`) VALUES ('Nana','BN267','oui', 'oui',100);
INSERT INTO `cooking`.`cdr` (`Pseudo`, `num_C`,`Cdr_Or`, `Cdr_Semaine`,`solde_cook`) VALUES ('Briquette01','BV354',null, null,0);

-- (2) insertion dans la table recette
INSERT INTO `cooking`.`recette` (`nom_recette`, `type`, `descriptif`,`prix_vente`,`Pseudo`) VALUES ('Couscous', 'Plat', '.....',20,'Juju');
INSERT INTO `cooking`.`recette` (`nom_recette`, `type`, `descriptif`,`prix_vente`,`Pseudo`) VALUES ('lasagne', 'Plat', '....',10,'Juju');
INSERT INTO `cooking`.`recette` (`nom_recette`, `type`, `descriptif`,`prix_vente`,`Pseudo`) VALUES ('Flan', 'Dessert', '....',20,'Nana');
INSERT INTO `cooking`.`recette` (`nom_recette`, `type`, `descriptif`,`prix_vente`,`Pseudo`) VALUES ('Fraisier', 'Dessert', '..',20,'Nana');
INSERT INTO `cooking`.`recette` (`nom_recette`, `type`, `descriptif`,`prix_vente`,`Pseudo`) VALUES ('Salade de choux', 'Entrée', '...',20,'Briquette01');

-- (1) insertion dans la table fournisseur
INSERT INTO `cooking`.`fournisseur` (`nom_fournisseur`, `tel_fournisseur`) VALUES ('Paul', 0645322113);
INSERT INTO `cooking`.`fournisseur` (`nom_fournisseur`, `tel_fournisseur`) VALUES ('Nicolas', 0613420973);

-- (2) insertion dans la table produit
INSERT INTO `cooking`.`produit` (`nom_produit`, `categorie`, `unit_qte`,`ref_fournisseur`,`nom_fournisseur`) VALUES ('Pomme', 'Fruit', 5,'PA13','Paul');
INSERT INTO `cooking`.`produit` (`nom_produit`, `categorie`, `unit_qte`,`ref_fournisseur`,`nom_fournisseur`) VALUES ('Fraise', 'Fruit', 15,'PA13','Paul');
INSERT INTO `cooking`.`produit` (`nom_produit`, `categorie`, `unit_qte`,`ref_fournisseur`,`nom_fournisseur`) VALUES ('Banane', 'Fruit', 5,'NI73','Paul');
INSERT INTO `cooking`.`produit` (`nom_produit`, `categorie`, `unit_qte`,`ref_fournisseur`,`nom_fournisseur`) VALUES ('Curry', 'Epice', 5,'NI73','Paul');
INSERT INTO `cooking`.`produit` (`nom_produit`, `categorie`, `unit_qte`,`ref_fournisseur`,`nom_fournisseur`) VALUES ('Sel', 'Epice', 20,'PA13','Paul');

INSERT INTO `cooking`.`se_compose`(`ref_recette`,`ref_produit`) VALUES ('Couscous','Pomme'),('Couscous','Fraise'),('Couscous','Banane');
-- (1) insertion dans la table commande
INSERT INTO `cooking`.`commande` (`num_commande`, `date`,`num_C`,`nom_recette`) VALUES ('BN267COUS', '2020-05-12','JG562','Couscous');
INSERT INTO `cooking`.`commande` (`num_commande`, `date`,`num_C`,`nom_recette`) VALUES ('BV354SAL', '2020-05-01','JG562','Couscous');



