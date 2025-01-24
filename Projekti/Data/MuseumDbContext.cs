using Microsoft.EntityFrameworkCore;
using Projekti.Models;
using System;

namespace Projekti.Data
{
    public class MuseumDbContext : DbContext
    {
        public MuseumDbContext(DbContextOptions<MuseumDbContext> options) : base(options) { }

        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Work>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.Property(w => w.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(w => w.Artist)
                    .HasMaxLength(100);

                entity.Property(w => w.Category)
                    .HasMaxLength(50);

                entity.Property(w => w.CreationDateText)
                    .HasMaxLength(50);

                entity.Property(w => w.Era)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 1, Name = "Laocoön and His Sons", Artist = "Agesander, Athenodoros, and Polydorus", Description = "A marble sculpture depicting the Trojan priest Laocoön and his sons being attacked by sea serpents.", Category = "Sculpture", CreationDate = null, CreationDateText = null, Era = "Ancient" },
                new Work { Id = 2, Name = "Venus de Milo", Artist = "Unknown", Description = "An ancient Greek statue representing Aphrodite, the goddess of love and beauty.", Category = "Sculpture", CreationDate = null, CreationDateText = "Approx. 150-100 BC", Era = "Ancient" },
                new Work { Id = 3, Name = "Rosetta Stone", Artist = "Unknown", Description = "A granodiorite stele inscribed with a decree in three scripts, key to deciphering Egyptian hieroglyphs.", Category = "Artifact", CreationDate = null, CreationDateText = "196 BC", Era = "Ancient" },
                new Work { Id = 4, Name = "The Codex Hammurabi", Artist = "Hammurabi", Description = "One of the earliest and most complete written legal codes from ancient Mesopotamia, inscribed on a large stone stele.", Category = "Artifact", CreationDate = null, CreationDateText = "1754 BC", Era = "Ancient" },
                new Work { Id = 5, Name = "The Book of Kells", Artist = "Unknown", Description = "A famous illuminated manuscript containing the four Gospels, created by Celtic monks.", Category = "Manuscript", CreationDate = null, CreationDateText = "800-01-01", Era = "Medieval" },
                new Work { Id = 6, Name = "The Bayeux Tapestry", Artist = "Unknown", Description = "A 70-meter-long embroidered cloth depicting the events leading up to the Norman conquest of England.", Category = "Tapestry", CreationDate = null, CreationDateText = "1070-01-01", Era = "Medieval" },
                new Work { Id = 7, Name = "The Arnolfini Portrait", Artist = "Jan van Eyck", Description = "A famous oil painting depicting Giovanni di Nicolao di Arnolfini and his wife Costanza Trenta.", Category = "Painting", CreationDate = null, CreationDateText = "1434-01-01", Era = "Medieval" },
                new Work { Id = 8, Name = "The Last Supper", Artist = "Leonardo da Vinci", Description = "A famous fresco depicting the moment Jesus announces that one of his disciples will betray him.", Category = "Painting", CreationDate = null, CreationDateText = "1495-01-01", Era = "Renaissance" },
                new Work { Id = 9, Name = "David", Artist = "Michelangelo", Description = "A marble sculpture representing the Biblical hero David, famous for its depiction of human anatomy.", Category = "Sculpture", CreationDate = null, CreationDateText = "1501-01-01", Era = "Renaissance" },
                new Work { Id = 10, Name = "Starry Night", Artist = "Vincent van Gogh", Description = "A famous painting known for its swirling, expressive representation of the night sky over Saint-Rémy-de-Provence.", Category = "Painting", CreationDate = null, CreationDateText = "1889-01-01", Era = "Modern" },
                new Work { Id = 11, Name = "The Persistence of Memory", Artist = "Salvador Dalí", Description = "A surrealist painting famous for its melting clocks, symbolizing the fluidity of time.", Category = "Painting", CreationDate = null, CreationDateText = "1931-01-01", Era = "Modern" },
                new Work { Id = 12, Name = "Guernica", Artist = "Pablo Picasso", Description = "A large mural painting depicting the bombing of the Basque town of Guernica during the Spanish Civil War.", Category = "Painting", CreationDate = null, CreationDateText = "1937-01-01", Era = "Modern" },
                new Work { Id = 13, Name = "The Thinker", Artist = "Auguste Rodin", Description = "A bronze sculpture depicting a man in deep contemplation, originally conceived as part of a larger work, The Gates of Hell.", Category = "Sculpture", CreationDate = null, CreationDateText = "1880-01-01", Era = "Modern" },
                new Work { Id = 14, Name = "The Scream", Artist = "Edvard Munch", Description = "An iconic expressionist painting symbolizing existential angst and fear.", Category = "Painting", CreationDate = null, CreationDateText = "1893-01-01", Era = "Modern" },
                new Work { Id = 15, Name = "The Kiss", Artist = "Gustav Klimt", Description = "A famous Art Nouveau painting depicting an intimate embrace, adorned with gold leaf.", Category = "Painting", CreationDate = null, CreationDateText = "1907-01-01", Era = "Modern" },
                new Work { Id = 16, Name = "The Lamentation", Artist = "Giotto di Bondone", Description = "A fresco that depicts the mourning of Christ, one of the key pieces of early Renaissance painting.", Category = "Fresco", CreationDate = null, CreationDateText = "1305-01-01", Era = "Medieval" },
                new Work { Id = 17, Name = "The Tres Riches Heures", Artist = "Unknown", Description = "A richly illuminated manuscript, considered the best example of French Gothic art.", Category = "Manuscript", CreationDate = null, CreationDateText = "1410-01-01", Era = "Medieval" },
                new Work { Id = 18, Name = "The Wilton Diptych", Artist = "Unknown", Description = "An English diptych depicting King Richard II and the Virgin Mary, showcasing late Gothic style.", Category = "Altarpiece", CreationDate = null, CreationDateText = "1395-01-01", Era = "Medieval" },
                new Work { Id = 19, Name = "The Annunciation", Artist = "Simone Martini", Description = "A masterpiece of Gothic art, a painting that shows the Virgin Mary receiving the message of Christ’s birth.", Category = "Painting", CreationDate = null, CreationDateText = "1333-01-01", Era = "Medieval" },
                new Work { Id = 20, Name = "The School of Athens", Artist = "Raphael", Description = "A fresco representing philosophy and knowledge, with many famous ancient philosophers.", Category = "Fresco", CreationDate = null, CreationDateText = "1510-01-01", Era = "Renaissance" },
                new Work { Id = 21, Name = "The Statue of Zeus at Olympias", Artist = "Phidias", Description = "One of the Seven Wonders of the Ancient World, a massive seated figure of Zeus made of ivory and gold.", Category = "Sculpture", CreationDate = null, CreationDateText = "435 BC", Era = "Ancient" }
            );
        }
    }
}

