-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: diplom
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `branches`
--

DROP TABLE IF EXISTS `branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branches` (
  `id_b` int NOT NULL AUTO_INCREMENT,
  `br_name` varchar(40) NOT NULL,
  PRIMARY KEY (`id_b`,`br_name`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branches`
--

LOCK TABLES `branches` WRITE;
/*!40000 ALTER TABLE `branches` DISABLE KEYS */;
INSERT INTO `branches` VALUES (1,'Комп\'ютерних технології'),(2,'Економічне'),(3,'Філологічне'),(4,'Транспортне');
/*!40000 ALTER TABLE `branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cont_parts`
--

DROP TABLE IF EXISTS `cont_parts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cont_parts` (
  `id_stud` int NOT NULL AUTO_INCREMENT,
  `vstup` int NOT NULL,
  `zag_ch` int NOT NULL,
  `spec_ch` int NOT NULL,
  `ekspl_ch` int NOT NULL,
  `techn_ch` int NOT NULL,
  `econom_ch` int NOT NULL,
  `op` int NOT NULL,
  `graph_ch1` int NOT NULL,
  `graph_ch2` int NOT NULL,
  `visnovok` int NOT NULL,
  PRIMARY KEY (`id_stud`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cont_parts`
--

LOCK TABLES `cont_parts` WRITE;
/*!40000 ALTER TABLE `cont_parts` DISABLE KEYS */;
INSERT INTO `cont_parts` VALUES (1,4,5,4,2,2,5,5,12,1,5),(2,4,10,20,8,0,5,5,2,1,0),(3,5,9,20,10,4,5,2,1,2,4),(4,4,9,15,4,2,5,4,12,2,1),(5,5,10,19,9,3,3,4,8,3,4);
/*!40000 ALTER TABLE `cont_parts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `g_roups`
--

DROP TABLE IF EXISTS `g_roups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `g_roups` (
  `id_grp` varchar(12) NOT NULL,
  `id_b` varchar(40) NOT NULL,
  `id_p` int DEFAULT NULL,
  PRIMARY KEY (`id_grp`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `g_roups`
--

LOCK TABLES `g_roups` WRITE;
/*!40000 ALTER TABLE `g_roups` DISABLE KEYS */;
INSERT INTO `g_roups` VALUES ('123-18-1/11','1',4),('125','3',4),('132','4',NULL),('151','2',4);
/*!40000 ALTER TABLE `g_roups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logim`
--

DROP TABLE IF EXISTS `logim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logim` (
  `login` varchar(20) NOT NULL,
  `pass` varchar(20) NOT NULL,
  `id_p` varchar(45) NOT NULL,
  PRIMARY KEY (`login`,`id_p`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logim`
--

LOCK TABLES `logim` WRITE;
/*!40000 ALTER TABLE `logim` DISABLE KEYS */;
INSERT INTO `logim` VALUES ('admin','admin','0'),('boba','boba','1'),('boyko12','boyko12','2'),('mar1','mar1','4');
/*!40000 ALTER TABLE `logim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `posit`
--

DROP TABLE IF EXISTS `posit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `posit` (
  `id_pos` int NOT NULL AUTO_INCREMENT,
  `pos_name` varchar(40) NOT NULL,
  `ac_lvl` int DEFAULT NULL,
  PRIMARY KEY (`id_pos`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `posit`
--

LOCK TABLES `posit` WRITE;
/*!40000 ALTER TABLE `posit` DISABLE KEYS */;
INSERT INTO `posit` VALUES (0,'admin',0),(1,'Зам. директора',1),(2,'Голова комисії ',2),(3,'Керівник',3),(4,'Зав. відділення ',4);
/*!40000 ALTER TABLE `posit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `id_p` int NOT NULL AUTO_INCREMENT,
  `fio` varchar(40) NOT NULL,
  `id_b` int NOT NULL,
  `pos` int DEFAULT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Бобров В.Е.',3,4),(2,'Бойко А.Ж.',2,3),(3,'Петросян Й.В.',4,1),(4,'Матросов І.П.',1,2),(5,'Чурсин К.В.',2,2);
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `students` (
  `id_stud` int NOT NULL AUTO_INCREMENT,
  `fio` varchar(40) NOT NULL,
  `id_grp` int NOT NULL,
  `ph_num` varchar(40) NOT NULL,
  `leader` int NOT NULL,
  PRIMARY KEY (`id_stud`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Сидоров В.П.',123,'+380215678321',2),(2,'Гришин А.А.',132,'+380167380987',2),(3,'Иванов Е.П.',151,'+380673894675',2),(4,'Петров Г.Г.',151,'+380648594638',0),(5,'Кошкина М.Н.',125,'+380544594668',0);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'diplom'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-05-28 15:53:02
