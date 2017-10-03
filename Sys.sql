use Tfs_DefaultCollection;	

select * from [sys].[database_files]


SELECT      c.name  AS 'ColumnName',t.name AS 'TableName'
FROM        sys.columns c
JOIN        sys.tables  t   ON c.object_id = t.object_id
WHERE       c.name LIKE '%ProjectId%'
ORDER BY    TableName, ColumnName;


select * from tbl_Project where IsDeleted = 0 order by ProjectName;

select * from UserProjects