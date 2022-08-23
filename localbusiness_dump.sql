-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: local_business
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20220819161449_Initial','5.0.0'),('20220819170135_SeedData','5.0.0'),('20220819203513_JWTToken','5.0.0');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `business`
--

DROP TABLE IF EXISTS `business`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `business` (
  `BusinessId` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`BusinessId`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `business`
--

LOCK TABLES `business` WRITE;
/*!40000 ALTER TABLE `business` DISABLE KEYS */;
INSERT INTO `business` VALUES (1,'Pho Love','Restaurant','6267778888','1 Technology Dr, Irvine, Ca 92618'),(2,'Four Sea Restaurant','Restaurant','4434425678','123 Alton Parkway, Irvine, Ca 92618'),(3,'Duke Bakery','Restaurant','8883332345','45 Jaboree Road, Irvine, Ca 92618'),(4,'TjMax','Shop','9098885643','166 Alliance Ave, Tustin Ca 92780'),(5,'Mayce','Shop','9092226789','678 Tomson Street, Tustin Ca 92780'),(6,'Kris Group','Clothing','9222614708','198 Mccormick Circle'),(7,'Olson-Stiedemann','Games','5731402245','79 Veith Avenue'),(8,'Beer-Jacobi','Movies','9156248852','5536 Fieldstone Park'),(9,'Greenholt, Ernser and Rowe','Grocery','8218512732','9 Upham Alley'),(10,'Turcotte, Macejkovic and Hilll','Outdoors','7659050813','6 Menomonie Alley'),(11,'Jast and Sons','Toys','7048465804','91 Anhalt Trail'),(12,'Runte-Hand','Sports','5445362658','4830 Straubel Terrace'),(13,'Davis-Oberbrunner','Outdoors','6225623118','7 Nobel Lane'),(14,'Vandervort-Kuvalis','Games','3169956685','289 Johnson Plaza'),(15,'Schumm, Fritsch and Legros','Garden','6431324115','6 Swallow Trail'),(16,'DuBuque Inc','Garden','4517143982','42500 Sunnyside Way'),(17,'Zboncak, Sanford and Mohr','Garden','2676097106','70559 Rigney Court'),(18,'Wilkinson Group','Shoes','2725073507','95091 Anniversary Terrace'),(19,'Miller and Sons','Automotive','7982166204','59315 Brown Lane'),(20,'Goodwin LLC','Automotive','7399404401','1 Drewry Alley'),(21,'Abbott, Connelly and Hermiston','Grocery','7076215907','48 Portage Parkway'),(22,'Tromp LLC','Health','2593322645','99971 Stang Hill'),(23,'Leffler-Bechtelar','Automotive','6348770244','11719 Transport Terrace'),(24,'Hudson LLC','Garden','4096647593','5801 Cambridge Parkway'),(25,'Kris, Mann and Erdman','Home','4793443372','7132 Kedzie Plaza'),(26,'Langworth-Hyatt','Beauty','6612452727','0 Declaration Terrace'),(27,'Heidenreich-Walsh','Toys','2921665836','718 Dawn Crossing'),(28,'Rolfson and Sons','Industrial','6948728341','43 Acker Road'),(29,'Yundt-Hegmann','Industrial','5668185811','95714 High Crossing Trail'),(30,'Upton, Runte and Stroman','Kids','3934867488','420 Fairview Parkway'),(31,'Ebert-Dickinson','Electronics','8746667974','06688 Moose Center');
/*!40000 ALTER TABLE `business` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-08-22 22:32:05
