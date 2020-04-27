USE `cooking`;

CREATE TABLE `cooking`.`client` (
  `num_C` VARCHAR(10) Not NULL,
  `nom_C` VARCHAR(20) NOT NULL,
  `prenom_C` VARCHAR(20) NULL, 
  `tel_C` INT NULL,
  `solde` INT NULL,
  PRIMARY KEY (`num_C`));

CREATE TABLE `cooking`.`cdr` (
  `Pseudo` VARCHAR(20) NOT NULL,
  `num_C` VARCHAR(20) NOT NULL,
  `CdR_Or` VARCHAR(20) NULL,
  `Cdr_Semaine` VARCHAR(20) NULL,
  `solde_cook` INT NULL,
  
  PRIMARY KEY (`Pseudo`),
  INDEX `F_client1_idx` (`num_C` ASC),
   CONSTRAINT `num_Ccdr` FOREIGN KEY (`num_C`)
		REFERENCES `cooking`.`client` (`num_C`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION );
  
  
CREATE TABLE `cooking`.`recette` (
  `nom_recette` VARCHAR(20) NOT NULL,
  `type` VARCHAR(20) NULL,
  `descriptif` VARCHAR(256) NULL,
  `prix_vente` INT NULL,
  `codeP` VARCHAR(4) NULL,
  `Pseudo` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`nom_recette`),
  INDEX `F_cdr2_idx` (`Pseudo` ASC),
   CONSTRAINT `Pseudorecette` FOREIGN KEY (`Pseudo`)
		REFERENCES `cooking`.`cdr` (`Pseudo`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION );
        
 CREATE TABLE `cooking`.`fournisseur` (
  `nom_fournisseur` VARCHAR(20) NOT NULL,
  `tel_fournisseur` INT NULL,
  PRIMARY KEY (`nom_fournisseur`) );
  
CREATE TABLE `cooking`.`produit` (
  `nom_produit` VARCHAR(20) NOT NULL,
  `categorie` VARCHAR(20) NOT NULL,
  `unit_qte` INT NULL,
  `ref_fournisseur` VARCHAR(30) NOT NULL,
  `nom_fournisseur` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`nom_produit`),
  INDEX `F_fournisseur1_idx` (`nom_fournisseur` ASC),
   CONSTRAINT `nom_fournisseurproduit` FOREIGN KEY (`nom_fournisseur`)
		REFERENCES `cooking`.`fournisseur` (`nom_fournisseur`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION);

CREATE TABLE `cooking`.`se_compose` (
`ref_recette` VARCHAR(20) NOT NULL, 
`ref_produit` VARCHAR(20) NOT NULL,
CONSTRAINT `FK_recette` FOREIGN KEY (`ref_recette`)
		REFERENCES `cooking`.`recette` (`nom_recette`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
CONSTRAINT `FK_produit` FOREIGN KEY (`ref_produit`)
		REFERENCES `cooking`.`produit` (`nom_produit`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
PRIMARY KEY(`ref_recette`,`ref_produit`));

CREATE TABLE `cooking`.`commande` (
  `num_Commande` VARCHAR(20) NOT NULL,
  `date` date,
  `num_C` VARCHAR(10) Not NULL,
  `nom_recette` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`num_Commande`),
  INDEX `F_client2_idx` (`num_C` ASC),
  INDEX `F_recette2_idx` (`nom_recette` ASC),
   CONSTRAINT `num_Ccommande` FOREIGN KEY (`num_C`)
		REFERENCES `cooking`.`client` (`num_C`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
	CONSTRAINT `nom_recettecommande` FOREIGN KEY (`nom_recette`)
		REFERENCES `cooking`.`recette` (`nom_recette`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION);
