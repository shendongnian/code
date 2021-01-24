	DECLARE @xml XML=
	N'<?xml version="1.0"?>
	<JobPositionPostings>
		<JobPositionPosting>
			<JobAction>ADD</JobAction>
			<JobType>p</JobType>
			<JobPositionPostingID>27</JobPositionPostingID>
			<HiringOrg>
				<HiringOrgName>Company Name</HiringOrgName>
				<Industry>
					<SummaryText>Brief description of the hiring organization</SummaryText>
				</Industry>
				<Contact>
					<PersonName>
						<FormattedName>Name of the Hiring Contact</FormattedName>
					</PersonName>
				</Contact>
			</HiringOrg>
			<JobDisplayOptions>
				<MicrositeName>Client Microsite Name</MicrositeName>
				<TemplateName>Client Template Name</TemplateName>
			</JobDisplayOptions>
            <!-- More nodes -->   
		</JobPositionPosting>
		<JobFeedResponseEmail>Tech person''s E-mail for receiving Feed Status</JobFeedResponseEmail>
	</JobPositionPostings>';
