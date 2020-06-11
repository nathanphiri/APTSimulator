-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.38-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             10.1.0.5464
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for aptsimulator
DROP DATABASE IF EXISTS `aptsimulator`;
CREATE DATABASE IF NOT EXISTS `aptsimulator` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `aptsimulator`;

-- Dumping structure for table aptsimulator.correct_response_choices
DROP TABLE IF EXISTS `correct_response_choices`;
CREATE TABLE IF NOT EXISTS `correct_response_choices` (
  `CHOICE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CHOICE_DESCRIPTION` varchar(50) NOT NULL,
  PRIMARY KEY (`CHOICE_ID`),
  UNIQUE KEY `CHOICE_DESCRIPTION` (`CHOICE_DESCRIPTION`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table aptsimulator.correct_response_choices: ~4 rows (approximately)
/*!40000 ALTER TABLE `correct_response_choices` DISABLE KEYS */;
REPLACE INTO `correct_response_choices` (`CHOICE_ID`, `CHOICE_DESCRIPTION`) VALUES
	(1, '1st Answer'),
	(2, '2nd Answer'),
	(3, '3rd Answer'),
	(0, 'Select');
/*!40000 ALTER TABLE `correct_response_choices` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.gender
DROP TABLE IF EXISTS `gender`;
CREATE TABLE IF NOT EXISTS `gender` (
  `CANDIDATE_GENDER_ID` int(11) NOT NULL AUTO_INCREMENT,
  `GENDER_DESC` varchar(50) NOT NULL,
  PRIMARY KEY (`CANDIDATE_GENDER_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table aptsimulator.gender: ~2 rows (approximately)
/*!40000 ALTER TABLE `gender` DISABLE KEYS */;
REPLACE INTO `gender` (`CANDIDATE_GENDER_ID`, `GENDER_DESC`) VALUES
	(1, 'Male'),
	(2, 'Female');
/*!40000 ALTER TABLE `gender` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.question
DROP TABLE IF EXISTS `question`;
CREATE TABLE IF NOT EXISTS `question` (
  `QUESTION_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY_ID` int(11) NOT NULL,
  `SECTION_ID` int(11) NOT NULL,
  `NARATION` blob NOT NULL,
  `QUESTION_STATUS_ID` int(11) NOT NULL DEFAULT '1',
  `IMG` mediumblob,
  PRIMARY KEY (`QUESTION_ID`),
  KEY `FK_QUESTION_question_category` (`CATEGORY_ID`),
  KEY `FK_question_question_section` (`SECTION_ID`),
  KEY `FK_question_question_status` (`QUESTION_STATUS_ID`),
  CONSTRAINT `FK_QUESTION_question_category` FOREIGN KEY (`CATEGORY_ID`) REFERENCES `question_category` (`CATEGORY_ID`),
  CONSTRAINT `FK_question_question_section` FOREIGN KEY (`SECTION_ID`) REFERENCES `question_section` (`SECTION_ID`),
  CONSTRAINT `FK_question_question_status` FOREIGN KEY (`QUESTION_STATUS_ID`) REFERENCES `question_status` (`STATUS_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=185 DEFAULT CHARSET=latin1;

-- Dumping data for table aptsimulator.question: ~0 rows (approximately)
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
REPLACE INTO `question` (`QUESTION_ID`, `CATEGORY_ID`, `SECTION_ID`, `NARATION`, `QUESTION_STATUS_ID`, `IMG`) VALUES
	(169, 1, 3, _binary 0x5768656E20796F75206172652064726976696E6720696E206475616C2063617272696164676520776179207468652072756C65206973852E2E, 1, NULL),
	(170, 1, 3, _binary 0x447572696E6720627265616B646F776E2C206974206973207265636F6D6D656E64656420746F852E, 1, NULL),
	(171, 1, 3, _binary 0x5768656E20676F696E6720737472616967687420617420612063726F7373726F616420, 1, NULL),
	(172, 1, 3, _binary 0x446F206E6F7420617474656D707420746F206F76657274616B6520656D657267656E63792076656869636C6573207768656E852E, 1, NULL),
	(173, 1, 3, _binary 0x556E646572206E6F726D616C20636F6E646974696F6E732C207768617420697320746865206D696E696D756D20666F6C6C6F77696E672064697374616E63652072756C6520666F72206D6F746F722076656869636C65733F, 1, NULL),
	(174, 1, 3, _binary 0x417420616E20696E74657273656374696F6E20636F6E74726F6C6C65642062792074726166666963206C69676874732C2073746561647920616D626572206172726F77207369676E696669657320746861742E2E2E20, 1, NULL),
	(175, 1, 3, _binary 0x57686174206973206578706563746564206F662074686520647269766572207768656E20617070726F6368696E6720746869732074797065206F6620696E74657273656374696F6E3F, 1, NULL),
	(176, 1, 3, _binary 0x4163636F7264696E6720746F204D616C61776920526F61642054726166666963204163742C207768617420697320746865206C6567616C20426C6F6F6420416C636F686F6C20436F6E63656E74726174696F6E20666F722061206472697665723F, 1, NULL),
	(177, 1, 3, _binary 0x5768696368206F662074686520666F6C6C6F77696E67206973207472756585, 1, NULL),
	(178, 1, 3, _binary 0x5768656E2064726976696E6720696E206275696C7420757020617265612C2074686520726567756C61746564206D6178696D756D2061636365707461626C652073706565646C696D6974206973852E2E, 1, NULL),
	(179, 1, 3, _binary 0x54686520666F6C6C6F77696E672073746174656D656E742069732066616C7365852E2E, 1, NULL),
	(180, 1, 3, _binary 0x466F7220612076656869636C6520746F2073746F70207468657265206973206E65656420746F20636F6E7369646572, 1, NULL),
	(181, 1, 3, _binary 0x54686520666F6C6C6F77696E672061726520726573706F6E736962696C6974696573206F662061206472697665722065786365707485, 1, NULL),
	(182, 1, 3, _binary 0x5768696368206F662074686520666F6C6C6F77696E67206973206120736572696F75732076656869636C6520646566656374, 1, NULL),
	(183, 1, 3, _binary 0x546865206D696E696D756D2061676520666F72206F627461696E696E6720612064726976696E67206C6963656E636520696E204D616C6177692069733A, 1, NULL);
/*!40000 ALTER TABLE `question` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.questions_per_section
DROP TABLE IF EXISTS `questions_per_section`;
CREATE TABLE IF NOT EXISTS `questions_per_section` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY_ID` int(11) NOT NULL,
  `SECTION_ID` int(11) NOT NULL,
  `NUMBER_OF_QUESTIONS` int(11) NOT NULL,
  `REQUIRED_SCORE` int(11) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_CATEGORY_ID_SECTION_ID` (`ID`,`CATEGORY_ID`,`SECTION_ID`),
  KEY `FK_questions_per_section_question_category` (`CATEGORY_ID`),
  KEY `FK_questions_per_section_question_section` (`SECTION_ID`),
  CONSTRAINT `FK_questions_per_section_question_category` FOREIGN KEY (`CATEGORY_ID`) REFERENCES `question_category` (`CATEGORY_ID`),
  CONSTRAINT `FK_questions_per_section_question_section` FOREIGN KEY (`SECTION_ID`) REFERENCES `question_section` (`SECTION_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1 COMMENT='Keeps track of the number of questions per section for each category ';

-- Dumping data for table aptsimulator.questions_per_section: ~6 rows (approximately)
/*!40000 ALTER TABLE `questions_per_section` DISABLE KEYS */;
REPLACE INTO `questions_per_section` (`ID`, `CATEGORY_ID`, `SECTION_ID`, `NUMBER_OF_QUESTIONS`, `REQUIRED_SCORE`) VALUES
	(1, 1, 2, 20, 15),
	(2, 1, 3, 20, 15),
	(3, 1, 4, 10, 7),
	(4, 2, 6, 40, 30),
	(5, 2, 7, 40, 30),
	(6, 3, 8, 20, 15),
	(7, 3, 9, 20, 15);
/*!40000 ALTER TABLE `questions_per_section` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.question_category
DROP TABLE IF EXISTS `question_category`;
CREATE TABLE IF NOT EXISTS `question_category` (
  `CATEGORY_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY_DESC` varchar(120) NOT NULL,
  PRIMARY KEY (`CATEGORY_ID`),
  UNIQUE KEY `CATEGODY_DESC` (`CATEGORY_DESC`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COMMENT='Keeps track of categories of APT Questions';

-- Dumping data for table aptsimulator.question_category: ~2 rows (approximately)
/*!40000 ALTER TABLE `question_category` DISABLE KEYS */;
REPLACE INTO `question_category` (`CATEGORY_ID`, `CATEGORY_DESC`) VALUES
	(1, 'Light / Heavy Motor Vehicle and Motorcycle LL Test'),
	(2, 'Light / Heavy Motor Vehicle Driver Licence Test'),
	(3, 'PrDP Test');
/*!40000 ALTER TABLE `question_category` ENABLE KEYS */;

-- Dumping structure for view aptsimulator.question_list
DROP VIEW IF EXISTS `question_list`;
-- Creating temporary table to overcome VIEW dependency errors
CREATE TABLE `question_list` (
	`QUESTION_ID` INT(11) NOT NULL,
	`QUESTION` BLOB NOT NULL,
	`CORRECT_ANSEWER` VARCHAR(300) NOT NULL COLLATE 'latin1_swedish_ci',
	`RESPONSE_NUMBER` INT(11) NOT NULL
) ENGINE=MyISAM;

-- Dumping structure for table aptsimulator.question_section
DROP TABLE IF EXISTS `question_section`;
CREATE TABLE IF NOT EXISTS `question_section` (
  `SECTION_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY_ID` int(11) NOT NULL,
  `SECTION_DESC` varchar(50) NOT NULL,
  PRIMARY KEY (`SECTION_ID`),
  UNIQUE KEY `SECTION_DESC` (`SECTION_DESC`),
  KEY `FK_QUESTION_SECTION_question_category` (`CATEGORY_ID`),
  CONSTRAINT `FK_QUESTION_SECTION_question_category` FOREIGN KEY (`CATEGORY_ID`) REFERENCES `question_category` (`CATEGORY_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1 COMMENT='Lookup table for sections for questions';

-- Dumping data for table aptsimulator.question_section: ~9 rows (approximately)
/*!40000 ALTER TABLE `question_section` DISABLE KEYS */;
REPLACE INTO `question_section` (`SECTION_ID`, `CATEGORY_ID`, `SECTION_DESC`) VALUES
	(1, 1, 'Practice Questions'),
	(2, 1, 'Road Signs and Signals'),
	(3, 1, 'Rules of the Road'),
	(4, 1, 'Vehicle Controls'),
	(5, 1, 'Light/Heavy Motor Vehicle'),
	(6, 2, 'Driving Light/Heavy Motor vehicle'),
	(7, 2, 'Driving Motorcycle'),
	(8, 3, 'Driving'),
	(9, 3, 'Dangerous Goods');
/*!40000 ALTER TABLE `question_section` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.question_status
DROP TABLE IF EXISTS `question_status`;
CREATE TABLE IF NOT EXISTS `question_status` (
  `STATUS_ID` int(11) NOT NULL AUTO_INCREMENT,
  `STATUS_DESCRIPTION` varchar(50) NOT NULL,
  PRIMARY KEY (`STATUS_ID`),
  UNIQUE KEY `STATUS_DESCRIPTION` (`STATUS_DESCRIPTION`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table aptsimulator.question_status: ~2 rows (approximately)
/*!40000 ALTER TABLE `question_status` DISABLE KEYS */;
REPLACE INTO `question_status` (`STATUS_ID`, `STATUS_DESCRIPTION`) VALUES
	(1, 'Active'),
	(2, 'Inactive');
/*!40000 ALTER TABLE `question_status` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.response
DROP TABLE IF EXISTS `response`;
CREATE TABLE IF NOT EXISTS `response` (
  `RESPONSE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `QUESTION_ID` int(11) NOT NULL,
  `RESPONSE_TYPE_ID` int(11) NOT NULL,
  `SEQUENSE_NUMBER_IN_QUESTION` int(11) NOT NULL,
  `NARATION` varchar(300) NOT NULL,
  PRIMARY KEY (`RESPONSE_ID`),
  KEY `FK_RESPONSE_question` (`QUESTION_ID`),
  KEY `FK_RESPONSE_response_type` (`RESPONSE_TYPE_ID`),
  CONSTRAINT `FK_RESPONSE_question` FOREIGN KEY (`QUESTION_ID`) REFERENCES `question` (`QUESTION_ID`),
  CONSTRAINT `FK_RESPONSE_response_type` FOREIGN KEY (`RESPONSE_TYPE_ID`) REFERENCES `response_type` (`RESPONSE_TYPE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=480 DEFAULT CHARSET=latin1 COMMENT='Responses to question';

-- Dumping data for table aptsimulator.response: ~0 rows (approximately)
/*!40000 ALTER TABLE `response` DISABLE KEYS */;
REPLACE INTO `response` (`RESPONSE_ID`, `QUESTION_ID`, `RESPONSE_TYPE_ID`, `SEQUENSE_NUMBER_IN_QUESTION`, `NARATION`) VALUES
	(432, 169, 1, 1, 'Keep left, pass right'),
	(434, 169, 2, 2, ' inner lane for fast moving vehicles'),
	(435, 169, 2, 3, 'overtake using any free lane'),
	(436, 170, 2, 1, 'get out of the vehicle in order to warn traffic coming from the front and back of the vehicle'),
	(437, 170, 1, 2, 'display warning triangles atleast 50metres in front and back of the vehicle'),
	(438, 170, 2, 3, 'warn oncoming traffic using tree branches at a reasonable distance in front and back of the vehicle '),
	(439, 171, 2, 1, ' use the extreme left lane and switch on the hazard lights'),
	(440, 171, 1, 2, ' use the extreme left lane and donot indicate'),
	(441, 171, 2, 3, ' use the inner lane and switch on the hazard lights'),
	(443, 172, 2, 1, 'they are in front of you'),
	(444, 172, 2, 2, 'they are driving slowly'),
	(445, 172, 1, 3, 'they are in an act of conducting an operation '),
	(446, 173, 1, 1, '2 seconds'),
	(447, 173, 2, 2, 'one vehicle gap'),
	(448, 173, 2, 3, '10 metres'),
	(449, 174, 2, 1, 'go in the dirrection of the arrow'),
	(450, 174, 1, 2, 'stop and wait for a green light before proceeding'),
	(451, 174, 2, 3, 'you may stop or go, if it is safe to do so'),
	(453, 175, 1, 1, 'Slow down, Stop and give precedence to vehicles approaching from the right hand side?'),
	(454, 175, 2, 2, 'Assess the intersection in advance and pass through without stopping if there no approaching vehicles'),
	(455, 175, 2, 3, 'If you have the right of way just drive through at your normal speed.'),
	(456, 176, 2, 1, '0.008g per 100ml of blood'),
	(457, 176, 2, 2, '0.8g per 100ml of blood'),
	(458, 176, 1, 3, '0.08g per 100ml of blood'),
	(459, 177, 2, 1, 'Use all mirrors, check all blind spotsreverse into the main road slowly.'),
	(460, 177, 1, 2, 'Use all mirrors, check all blind spots and reverse slowly'),
	(461, 177, 2, 3, 'Use all mirrors, turn your head physically to check around and reverse as long as you can'),
	(462, 178, 1, 1, '50km/hr'),
	(463, 178, 2, 2, '40km/hr'),
	(464, 178, 2, 3, '60km/hr'),
	(465, 179, 2, 1, 'Never stop closs to or on the actual railway line'),
	(466, 179, 2, 2, 'At level crossing with no signs or signals, listen out for approaching trains'),
	(467, 179, 1, 3, 'Do not yield precedence when approaching rail-road crossing'),
	(468, 180, 2, 1, 'Reaction distance and Stopping distance'),
	(469, 180, 1, 2, 'Reaction distance and braking distance'),
	(470, 180, 2, 3, 'Braking distance and stopping Distance'),
	(471, 181, 2, 1, 'Should ensure that all passengers have fastened their seatbelts'),
	(472, 181, 2, 2, 'Should not allow a passenger to interfer with the driving'),
	(473, 181, 1, 3, 'Ensuring that other road are adhering to traffic rules and regulations'),
	(474, 182, 1, 1, 'Worn out tyres'),
	(475, 182, 2, 2, 'Faulty horn'),
	(476, 182, 2, 3, 'Expired Certificate of Fitness (COF)'),
	(477, 183, 2, 1, '21 years'),
	(478, 183, 1, 2, '18 years'),
	(479, 183, 2, 3, '19 years');
/*!40000 ALTER TABLE `response` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.response_type
DROP TABLE IF EXISTS `response_type`;
CREATE TABLE IF NOT EXISTS `response_type` (
  `RESPONSE_TYPE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `RESPONSE_TYPE_VALUE` varchar(50) NOT NULL,
  PRIMARY KEY (`RESPONSE_TYPE_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 COMMENT='Type of Response to Questions';

-- Dumping data for table aptsimulator.response_type: ~2 rows (approximately)
/*!40000 ALTER TABLE `response_type` DISABLE KEYS */;
REPLACE INTO `response_type` (`RESPONSE_TYPE_ID`, `RESPONSE_TYPE_VALUE`) VALUES
	(1, 'Correct'),
	(2, 'Wrong');
/*!40000 ALTER TABLE `response_type` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.test_results
DROP TABLE IF EXISTS `test_results`;
CREATE TABLE IF NOT EXISTS `test_results` (
  `RESULT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `TEST_SCHEDULE_ID` int(11) NOT NULL,
  `SECTION_ID` int(11) NOT NULL,
  `TEST_SCORE` int(11) NOT NULL,
  PRIMARY KEY (`RESULT_ID`),
  KEY `FK_test_results_test_schedule` (`TEST_SCHEDULE_ID`),
  KEY `FK_test_results_questions_per_section` (`SECTION_ID`),
  CONSTRAINT `FK_test_results_questions_per_section` FOREIGN KEY (`SECTION_ID`) REFERENCES `questions_per_section` (`SECTION_ID`),
  CONSTRAINT `FK_test_results_test_schedule` FOREIGN KEY (`TEST_SCHEDULE_ID`) REFERENCES `test_schedule` (`SCHEDULE_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Keeps results of each test performed';

-- Dumping data for table aptsimulator.test_results: ~0 rows (approximately)
/*!40000 ALTER TABLE `test_results` DISABLE KEYS */;
/*!40000 ALTER TABLE `test_results` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.test_schedule
DROP TABLE IF EXISTS `test_schedule`;
CREATE TABLE IF NOT EXISTS `test_schedule` (
  `SCHEDULE_ID` int(11) NOT NULL AUTO_INCREMENT,
  `CATEGORY_ID` int(11) NOT NULL,
  `CANDIDATE_FNAME` varchar(50) NOT NULL,
  `CANDIDATE_LNAME` varchar(50) NOT NULL,
  `CANDIDATE_DOB` date NOT NULL,
  `CANDIDATE_GENDER` int(11) NOT NULL,
  `SCHEDULE_DATE` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `SCHEDULE_STATUS_ID` int(11) NOT NULL DEFAULT '1',
  PRIMARY KEY (`SCHEDULE_ID`),
  KEY `FK_test_schedule_gender` (`CANDIDATE_GENDER`),
  KEY `FK_test_schedule_question_category` (`CATEGORY_ID`),
  KEY `FK_test_schedule_test_schedule_status` (`SCHEDULE_STATUS_ID`),
  CONSTRAINT `FK_test_schedule_gender` FOREIGN KEY (`CANDIDATE_GENDER`) REFERENCES `gender` (`CANDIDATE_GENDER_ID`),
  CONSTRAINT `FK_test_schedule_question_category` FOREIGN KEY (`CATEGORY_ID`) REFERENCES `question_category` (`CATEGORY_ID`),
  CONSTRAINT `FK_test_schedule_test_schedule_status` FOREIGN KEY (`SCHEDULE_STATUS_ID`) REFERENCES `test_schedule_status` (`SCHEDULE_STATUS_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1 COMMENT='Keeps details of each scheduled test';

-- Dumping data for table aptsimulator.test_schedule: ~3 rows (approximately)
/*!40000 ALTER TABLE `test_schedule` DISABLE KEYS */;
REPLACE INTO `test_schedule` (`SCHEDULE_ID`, `CATEGORY_ID`, `CANDIDATE_FNAME`, `CANDIDATE_LNAME`, `CANDIDATE_DOB`, `CANDIDATE_GENDER`, `SCHEDULE_DATE`, `SCHEDULE_STATUS_ID`) VALUES
	(8, 1, 'CLEMENT', 'PHIRI', '2004-12-31', 1, '2020-04-15 11:00:32', 1),
	(9, 1, 'YEWO', 'PHIRI', '2004-12-23', 2, '2020-04-15 11:00:34', 1),
	(10, 1, 'MIKE', 'CHIBAKA', '1989-01-12', 1, '2020-04-21 11:41:09', 1);
/*!40000 ALTER TABLE `test_schedule` ENABLE KEYS */;

-- Dumping structure for table aptsimulator.test_schedule_status
DROP TABLE IF EXISTS `test_schedule_status`;
CREATE TABLE IF NOT EXISTS `test_schedule_status` (
  `SCHEDULE_STATUS_ID` int(11) NOT NULL AUTO_INCREMENT,
  `STATUS_DESCPTION` varchar(50) NOT NULL,
  PRIMARY KEY (`SCHEDULE_STATUS_ID`),
  UNIQUE KEY `STATUS_DESCPTION` (`STATUS_DESCPTION`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table aptsimulator.test_schedule_status: ~2 rows (approximately)
/*!40000 ALTER TABLE `test_schedule_status` DISABLE KEYS */;
REPLACE INTO `test_schedule_status` (`SCHEDULE_STATUS_ID`, `STATUS_DESCPTION`) VALUES
	(2, 'Invalid'),
	(1, 'Valid');
/*!40000 ALTER TABLE `test_schedule_status` ENABLE KEYS */;

-- Dumping structure for view aptsimulator.question_list
DROP VIEW IF EXISTS `question_list`;
-- Removing temporary table and create final VIEW structure
DROP TABLE IF EXISTS `question_list`;
CREATE ALGORITHM=UNDEFINED DEFINER=`inventory`@`%` SQL SECURITY DEFINER VIEW `question_list` AS SELECT question.QUESTION_ID, question.NARATION AS QUESTION, response.NARATION AS CORRECT_ANSEWER,response.SEQUENSE_NUMBER_IN_QUESTION AS RESPONSE_NUMBER FROM question
INNER JOIN response ON question.QUESTION_ID=response.QUESTION_ID
WHERE question.QUESTION_STATUS_ID=1
AND response.RESPONSE_TYPE_ID=1 ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
