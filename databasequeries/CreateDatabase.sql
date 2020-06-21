--Recreate the entire database
USE SampleInsurance;
DROP TABLE Benefits;
DROP TABLE Policies;
CREATE table Policies ( PolicyNumber INT IDENTITY(1,1) PRIMARY KEY, 
                        EffectiveDate Date NOT NULL, 
                        PaidThroughDate Date NULL, 
                        ExpiryDate Date NOT NULL, 
                        PolicyStatus VARCHAR(20) NOT NULL
);
CREATE table Benefits ( BenefitId INT IDENTITY(1,1) PRIMARY KEY,
                        PolicyNumber INT NOT NULL,                        
                        BenefitCode VARCHAR(20) NOT NULL,
                        BenefitEffectiveDate Date, 
                        BenefitExpiryDate Date,
                        CONSTRAINT fk_policies FOREIGN KEY (PolicyNumber) REFERENCES Policies(PolicyNumber)
);
