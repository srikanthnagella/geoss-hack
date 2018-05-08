# Generated by Django 2.0.2 on 2018-05-07 12:13

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('game', '0004_auto_20180504_1004'),
    ]

    operations = [
        migrations.RenameField(
            model_name='imagetile',
            old_name='score',
            new_name='machineScore',
        ),
        migrations.AddField(
            model_name='imagetile',
            name='userScore',
            field=models.OneToOneField(default=0, on_delete=django.db.models.deletion.CASCADE, related_name='userScore', to='game.Score'),
            preserve_default=False,
        ),
    ]
