from django.db import models

# Create your models here.

class Score(models.Model):  
    opaqueCloud = models.IntegerField()
    thinCloud = models.IntegerField()
    thickCloud = models.IntegerField()
    land = models.IntegerField( )
    water = models.IntegerField()
    snow = models.IntegerField()

class ImageFile(models.Model):
    filename = models.TextField()


class ImageTile(models.Model):
    fileid = models.ForeignKey('ImageFile', on_delete=models.CASCADE)
    tileid   = models.IntegerField()
    userScore = models.OneToOneField('Score', related_name='userScore',on_delete=models.CASCADE)
    machineScore = models.OneToOneField('Score', related_name='machineScore', on_delete=models.CASCADE)

